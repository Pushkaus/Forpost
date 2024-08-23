using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Abstract.Services;
using Forpost.Business.EventHanding;
using Forpost.Business.Events.Products;
using Forpost.Business.Models.InvoiceProducts;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using InvoiceProduct = Forpost.Store.Entities.InvoiceProduct;

namespace Forpost.Business.Services;

internal sealed class InvoiceProductService : BaseBusinessService, IInvoiceProductService
{
    private readonly IDomainEventBus _eventBus;
    public InvoiceProductService(
        IDbUnitOfWork dbUnitOfWork,
        ILogger<BaseBusinessService> logger,
        IMapper mapper,
        IConfiguration configuration,
        TimeProvider timeProvider, IDomainEventBus eventBus)
        : base(dbUnitOfWork, logger, mapper, configuration, timeProvider)
    {
        _eventBus = eventBus;
    }

    public async Task AddAsync(InvoiceProductCreateModel model, CancellationToken cancellationToken)
    {
        var invoiceProduct = Mapper.Map<InvoiceProduct>(model);
        await _eventBus.PublishAsync(new ProductInInvoiceAdded
        {
            InvoiceId = invoiceProduct.InvoiceId,
            ProductId = invoiceProduct.ProductId,
            Quantity = invoiceProduct.Quantity
        }, cancellationToken);
        DbUnitOfWork.InvoiceProductRepository.Add(invoiceProduct);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<InvoiceProductModel?>>
        GetProductsByInvoiceIdAsync(Guid id, CancellationToken cancellationToken)
    {
        // await _eventBus.PublishAsync(new ProductInInvoiceAdded
        // {
        //     InvoiceId = id,
        //     ProductId = Guid.NewGuid(),
        //     Quantity = 1000
        // });
        //
        // await _eventBus.PublishAsync(new ProductInInvoiceAdded2
        // {
        //     InvoiceId = id,
        //     ProductId = Guid.NewGuid(),
        //     Quantity = 1000
        // });
        //
        var invoiceProducts = await DbUnitOfWork.InvoiceProductRepository.GetProductsByInvoiceIdAsync(id, cancellationToken);
        var response = Mapper.Map<IReadOnlyList<InvoiceProductModel>>(invoiceProducts);
        return response;
    }

    public async Task UpdateAsync(InvoiceProductCreateModel model, CancellationToken cancellationToken)
    {
        var invoiceProduct = Mapper.Map<InvoiceProduct>(model);
        DbUnitOfWork.InvoiceProductRepository.Update(invoiceProduct);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByProductIdAsync(Guid id, CancellationToken cancellationToken)
    {
        await DbUnitOfWork.InvoiceProductRepository.DeleteByProductIdAsync(id, cancellationToken);
    }
}