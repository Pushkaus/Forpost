using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using Forpost.Application.Contracts.InvoiceManagment.Invoices;
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

    public async Task<(IReadOnlyCollection<InvoiceModel> Invoices, int TotalCount)> GetAll(
        CancellationToken cancellationToken,
        int skip,
        int limit,
        string filterExpression,
        object?[]? filterValues)
    {
        var query = _dbContext.Invoices.Where(x => x.DeletedAt == null)
            .Join(
                _dbContext.Contractors,
                invoice => invoice.ContractorId,
                contractor => contractor.Id,
                (invoice, contractor) => new InvoiceModel
                {
                    Id = invoice.Id,
                    Number = invoice.Number,
                    ContractorId = contractor.Id,
                    ContractorName = contractor.Name,
                    Description = invoice.Description,
                    PaymentPercentage = invoice.PaymentPercentage,
                    DaysShipment = invoice.DaysShipment,
                    Status = invoice.Status,
                    DateShipment = invoice.DateShipment,
                }
            );

        // Применение фильтрации, если выражение задано
        if (!string.IsNullOrWhiteSpace(filterExpression))
        {
            try
            {
                query = query.Where($"{filterExpression}.Contains(@0)", filterValues);
            }
            catch (ParseException ex)
            {
                throw new ArgumentException("Некорректное выражение фильтрации.", ex);
            }
        }
        var totalCount = await query.CountAsync(cancellationToken);

        var invoices = await query
            .Skip(skip)
            .Take(limit)
            .ToListAsync(cancellationToken);

        return (invoices, totalCount);
    }
}
