using System.Linq.Dynamic.Core;
using Forpost.Application.Contracts;
using Forpost.Application.Contracts.CRM.InvoiceManagement.Invoices;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class InvoiceReadRepository : IInvoiceReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public InvoiceReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<EntityPagedResult<InvoiceModel>> GetAllAsync(InvoiceFilter filter,
        CancellationToken cancellationToken)
    {
        IQueryable<Invoice> query = _dbContext.Invoices.NotDeletedAt();

        if (!string.IsNullOrEmpty(filter.Number))
        {
            query = query.Where(i => i.Number.Contains(filter.Number));
        }

        if (filter.ContractorId.HasValue)
        {
            query = query.Where(i => i.ContractorId == filter.ContractorId.Value);
        }

        if (filter.DateShipment.HasValue)
        {
            query = query.Where(i =>
                i.DateShipment != null && i.DateShipment.Value.Date == filter.DateShipment.Value.Date);
        }

        if (filter.DateClosing.HasValue)
        {
            query = query.Where(i =>
                i.DateClosing != null && i.DateClosing.Value.Date == filter.DateClosing.Value.Date);
        }

        if (filter.Priority.HasValue)
        {
            query = query.Where(i => i.Priority == Priority.FromValue(filter.Priority.Value));
        }

        if (filter.PaymentStatus.HasValue)
        {
            query = query.Where(i => i.PaymentStatus == PaymentStatus.FromValue(filter.PaymentStatus.Value));
        }

        if (filter.InvoiceStatus.HasValue)
        {
            query = query.Where(i => i.InvoiceStatus == InvoiceStatus.FromValue(filter.InvoiceStatus.Value));
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var invoices = await query
            .Join(_dbContext.Contractors,
                invoice => invoice.ContractorId,
                contractor => contractor.Id,
                (invoice, contractor) => new InvoiceModel
                {
                    Id = invoice.Id,
                    Number = invoice.Number,
                    ContractorId = invoice.ContractorId,
                    ContragentName = contractor.Name,
                    PaymentPercentage = invoice.PaymentPercentage,
                    Description = invoice.Description,
                    CreateDate = invoice.CreateDate, 
                    CreatedAt = invoice.CreatedAt,
                    DateShipment = invoice.DateShipment,
                    DateClosing = invoice.DateClosing,
                    PaymentDeadline = invoice.PaymentDeadline,
                    Priority = invoice.Priority,
                    PaymentStatus = invoice.PaymentStatus,
                    InvoiceStatus = invoice.InvoiceStatus,
                })
            .OrderByDescending(date => date.CreatedAt)
            .Skip(filter.Skip)
            .Take(filter.Limit)
            .ToListAsync(cancellationToken);

        return new EntityPagedResult<InvoiceModel>
        {
            Items = invoices,
            TotalCount = totalCount
        };
    }

    public Task<InvoiceModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        _dbContext.Invoices
            .Join(_dbContext.Contractors,
                invoice => invoice.ContractorId,
                contractor => contractor.Id,
                (invoice, contractor) => new InvoiceModel
                {
                    Id = invoice.Id,
                    Number = invoice.Number,
                    ContractorId = invoice.ContractorId,
                    ContragentName = contractor.Name,
                    PaymentPercentage = invoice.PaymentPercentage,
                    Description = invoice.Description,
                    CreateDate = invoice.CreateDate, 
                    CreatedAt = invoice.CreatedAt,
                    DateShipment = invoice.DateShipment,
                    DateClosing = invoice.DateClosing,
                    PaymentDeadline = invoice.PaymentDeadline,
                    Priority = invoice.Priority,
                    PaymentStatus = invoice.PaymentStatus,
                    InvoiceStatus = invoice.InvoiceStatus,
                }).FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
}