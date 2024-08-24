using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Abstract.Services;
using Forpost.Business.EventHanding;
using Forpost.Business.Models.Invoices;
using Forpost.Store.Entities;
using Forpost.Store.Enums;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Services;

public class InvoiceModel
{
    public string Name { get; set; } = null!;
}

internal sealed class InvoiceService : BusinessService, IInvoiceService
{
    public InvoiceService(
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

    public async Task<InvoiceEntity?> GetByNumberAsync(string number, CancellationToken cancellationToken)
    {
        var invoice = await DbUnitOfWork.InvoiceRepository.GetByNumberAsync(number, cancellationToken);
        return invoice;
    }

    public async Task<IReadOnlyList<InvoiceEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        var invoices = await DbUnitOfWork.InvoiceRepository.GetAllAsync(cancellationToken);
        return invoices;
    }

    public async Task<Guid> ExposeAsync(InvoiceCreateModel model, CancellationToken cancellationToken)
    {
        var invoice = Mapper.Map<InvoiceEntity>(model);
        invoice.IssueStatus = IssueStatus.Pending; // Заводя счет, выставляется статус - ожидаемый
        DbUnitOfWork.InvoiceRepository.Add(invoice);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
        
        return Guid.Empty;
    }

    public async Task CloseAsync(InvoiceUpdateModel model, CancellationToken cancellationToken)
    {
        model.IssueStatus = IssueStatus.Completed;
        model.DateShipment = TimeProvider.GetUtcNow();
        var invoice = Mapper.Map<InvoiceEntity>(model);
        DbUnitOfWork.InvoiceRepository.Update(invoice);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(InvoiceUpdateModel model, CancellationToken cancellationToken)
    {
        var invoice = Mapper.Map<InvoiceEntity>(model);
        DbUnitOfWork.InvoiceRepository.Update(invoice);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        DbUnitOfWork.InvoiceRepository.DeleteById(id);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }
}