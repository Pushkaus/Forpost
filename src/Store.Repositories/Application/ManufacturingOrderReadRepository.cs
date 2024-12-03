using System.Linq.Dynamic.Core;
using Forpost.Application.Contracts;
using Forpost.Application.Contracts.ProductCreating.ManufacturingOrders;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Domain.ProductCreating.ManufacturingOrders;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class ManufacturingOrderReadRepository : IManufacturingOrderReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public ManufacturingOrderReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EntityPagedResult<ManufacturingOrderModel>> GetAllManufacturingOrdersAsync(
        ManufacturingOrderFilter filter, CancellationToken cancellationToken)
    {
        var query = _dbContext.ManufacturingOrders.NotDeletedAt()
            .Join(_dbContext.Invoices,
                manufacturingOrder => manufacturingOrder.InvoiceId,
                invoice => invoice.Id,
                (manufacturingOrder, invoice) => new ManufacturingOrderModel
                {
                    Id = manufacturingOrder.Id,
                    InvoiceId = manufacturingOrder.InvoiceId,
                    Number = invoice.Number,
                    Description = invoice.Description,
                    Priority = invoice.Priority,
                    Comment = manufacturingOrder.Comment,
                    CreatedAt = manufacturingOrder.CreatedAt,
                    ManufacturingOrderStatus = manufacturingOrder.ManufacturingOrderStatus,
                });

        if (!string.IsNullOrEmpty(filter.Number))
        {
            query = query.Where(m => m.Number.Contains(filter.Number));
        }

        if (filter.Priority.HasValue)
        {
            query = query.Where(m => m.Priority == Priority.FromValue(filter.Priority.Value));
        }

        if (filter.ManufacturingOrderStatusValue.HasValue)
        {
            query = query.Where(m =>
                m.ManufacturingOrderStatus ==
                ManufacturingOrderStatus.FromValue(filter.ManufacturingOrderStatusValue.Value));
        }
        var totalCount = await query.CountAsync(cancellationToken);
        var manufacturingOrders = await query
            .Skip(filter.Skip)
            .Take(filter.Limit)
            .OrderByDescending(x => x.Priority)
            .ToListAsync(cancellationToken);

        return new EntityPagedResult<ManufacturingOrderModel>
        {
            TotalCount = totalCount,
            Items = manufacturingOrders
        };
    }

    public async Task<ManufacturingOrderModel?> GetManufacturingOrderByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        return await _dbContext.ManufacturingOrders
            .Join(_dbContext.Invoices,
                manufacturingOrder => manufacturingOrder.InvoiceId,
                invoice => invoice.Id,
                (manufacturingOrder, invoice) => new ManufacturingOrderModel
                {
                    Id = manufacturingOrder.Id,
                    InvoiceId = manufacturingOrder.InvoiceId,
                    Number = invoice.Number,
                    Description = invoice.Description,
                    Priority = invoice.Priority,
                    Comment = manufacturingOrder.Comment,
                    CreatedAt = manufacturingOrder.CreatedAt,
                    ManufacturingOrderStatus = manufacturingOrder.ManufacturingOrderStatus,
                }).FirstOrDefaultAsync(cancellationToken);
    }
}