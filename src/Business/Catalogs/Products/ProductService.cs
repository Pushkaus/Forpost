using AutoMapper;
using Forpost.Business.Catalogs.Products.Commands;
using Forpost.EventBus;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Catalogs.Products;

internal sealed class ProductService : BusinessService, IProductService
{
    public ProductService(
        IDbUnitOfWork dbUnitOfWork,
        ILogger<BusinessService> logger,
        IMapper mapper,
        IConfiguration configuration,
        IDomainEventBus domainEventBus,
        TimeProvider timeProvider
    )
        : base(dbUnitOfWork, logger, mapper, configuration, domainEventBus, timeProvider)
    {
    }

    public async Task<IReadOnlyList<ProductEntity>> GetAllAsync(CancellationToken cancellationToken) 
        => await DbUnitOfWork.ProductRepository.GetAllAsync(cancellationToken);

    public async Task<Guid> AddAsync(ProductCreateCommand model, CancellationToken cancellationToken)
    {
        var product = Mapper.Map<ProductEntity>(model);
        var productId = DbUnitOfWork.ProductRepository.Add(product);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
        return productId;
    }

    public async Task<ProductEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await DbUnitOfWork.ProductRepository.GetByIdAsync(id, cancellationToken);

    public async Task UpdateAsync(ProductUpdateCommand model, CancellationToken cancellationToken)
    {
        var product = Mapper.Map<ProductEntity>(model);
        DbUnitOfWork.ProductRepository.Update(product);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        DbUnitOfWork.ProductRepository.DeleteById(id);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }
}