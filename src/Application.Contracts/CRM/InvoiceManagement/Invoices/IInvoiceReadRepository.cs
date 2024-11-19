using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.CRM.InvoiceManagement.Invoices;

public interface IInvoiceReadRepository : IApplicationReadRepository
{
    public Task<EntityPagedResult<InvoiceModel>> GetAllAsync(InvoiceFilter filter, CancellationToken cancellationToken);
    public Task<InvoiceModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}