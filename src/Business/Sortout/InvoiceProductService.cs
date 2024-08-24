using AutoMapper;
using Forpost.EventBus;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Sortout;

internal sealed class InvoiceProductService : BusinessService, IInvoiceProductService
{
    public InvoiceProductService(
        IDbUnitOfWork dbUnitOfWork,
        ILogger<BusinessService> logger,
        IMapper mapper,
        IConfiguration configuration,
        IDomainEventBus domainEventBus,
        TimeProvider timeProvider)
        : base(dbUnitOfWork, logger, mapper, configuration, domainEventBus, timeProvider)
    {
    }

    public async Task AddAsync(InvoiceProductCreate model, CancellationToken cancellationToken)
    {
        var invoiceProduct = Mapper.Map<InvoiceProductEntity>(model);
        DbUnitOfWork.InvoiceProductRepository.Add(invoiceProduct);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<InvoiceProduct?>>
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
        var response = Mapper.Map<IReadOnlyList<InvoiceProduct>>(invoiceProducts);
        return response;
    }

    public async Task UpdateAsync(InvoiceProductCreate model, CancellationToken cancellationToken)
    {
        var invoiceProduct = Mapper.Map<InvoiceProductEntity>(model);
        DbUnitOfWork.InvoiceProductRepository.Update(invoiceProduct);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByProductIdAsync(Guid id, CancellationToken cancellationToken)
    {
        await DbUnitOfWork.InvoiceProductRepository.DeleteByProductIdAsync(id, cancellationToken);
    }
}