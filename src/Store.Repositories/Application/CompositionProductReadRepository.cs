using Forpost.Application.Contracts.ProductCreating.CompositionProduct;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class CompositionProductReadRepository: ICompositionProductReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public CompositionProductReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<CompositionProductGroupModel>> 
    GetCompositionProduct(Guid productDevelopmentId, CancellationToken cancellationToken)
{
    var groupedData = await _dbContext.CompositionProducts
        .Where(cp => cp.ProductId == productDevelopmentId)

        .Join(_dbContext.ProductDevelopments,
            cp => cp.ProductId,
            pd => pd.Id,
            (cp, pd) => new { CompositionProductParent = cp, ProductDevelopmentParent = pd })

        // Соединяем с таблицей Products для получения информации о родительском продукте
        .Join(_dbContext.Products,
            combined => combined.ProductDevelopmentParent.ProductId,
            parentProduct => parentProduct.Id,
            (combined, parentProduct) => new 
            { 
                combined.CompositionProductParent, 
                combined.ProductDevelopmentParent, 
                ParentProduct = parentProduct 
            })
        .Join(_dbContext.CompletedProducts,
            combined => combined.CompositionProductParent.ItemId,
            item => item.Id,
            (combined, item) => new
            {
                combined,
                item
            })
        .Join(_dbContext.ProductDevelopments,
            itemDevelopment => itemDevelopment.item.ProductDevelopmentId,
            productItemDevelopment => productItemDevelopment.Id,
            (itemDevelopment, productItemDevelopment) => new {itemDevelopment, productItemDevelopment})
        .Join(_dbContext.Products,
            combined => combined.productItemDevelopment.ProductId,
            itemProduct => itemProduct.Id,
            (combined, itemProduct) => new {combined, itemProduct})
        // Группируем по ProductDevelopmentId, ParentProductName и SerialNumber
        .GroupBy(x => new 
        { 
            x.combined.itemDevelopment.combined.CompositionProductParent.ProductId, 
            x.combined.itemDevelopment.combined.ParentProduct.Name,
            x.combined.itemDevelopment.combined.ProductDevelopmentParent.SerialNumber,
            ItemId = x.combined.itemDevelopment.combined.CompositionProductParent.ItemId,
            ItemName = x.itemProduct.Name,
            SerialNumberItem = x.combined.productItemDevelopment.SerialNumber
        })

        // Проецируем в CompositionProductGroupModel
        .Select(g => new CompositionProductGroupModel
        {
            ProductDevelopmentId = g.Key.ProductId,
            ParentProductName = g.Key.Name,
            SerialNumber = g.Key.SerialNumber,
            CompletedProducts = g.Select(x => new CompletedProductModel
            {
                CompletedProductId = g.Key.ItemId,
                ItemName = g.Key.ItemName,
                // Если SerialNumber для CompletedProductModel должен быть таким же, как у группы
                // или получен из другого источника, установите его соответствующим образом
                SerialNumber = g.Key.SerialNumberItem // Или назначьте другое значение
            }).ToList()
        })

        // Асинхронное выполнение запроса
        .ToListAsync(cancellationToken);

    return groupedData;
}



}