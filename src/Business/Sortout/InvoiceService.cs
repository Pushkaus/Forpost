using AutoMapper;
using Forpost.EventBus;
using Forpost.Store.Entities;
using Forpost.Store.Enums;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Sortout;

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

    public async Task<Guid> ExposeAsync(InvoiceCreateCommand model, CancellationToken cancellationToken)
    {
        var invoice = Mapper.Map<InvoiceEntity>(model);
        invoice.IssueStatus = IssueStatus.Pending; // Заводя счет, выставляется статус - ожидаемый
        DbUnitOfWork.InvoiceRepository.Add(invoice);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
        
        return Guid.Empty;
    }

    public async Task CloseAsync(InvoiceUpdateCommand model, CancellationToken cancellationToken)
    {
        model.IssueStatus = IssueStatus.Completed;
        model.DateShipment = TimeProvider.GetUtcNow();
        var invoice = Mapper.Map<InvoiceEntity>(model);
        DbUnitOfWork.InvoiceRepository.Update(invoice);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(InvoiceUpdateCommand model, CancellationToken cancellationToken)
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