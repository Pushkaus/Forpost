using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.InvoiceManagment.Invoices;

public interface IInvoiceReadRepository: IApplicationReadRepository
{
    public Task<(IReadOnlyCollection<InvoiceModel> Invoices, int TotalCount)> GetAll(
        CancellationToken cancellationToken,
        int skip, int limit, string? filterExpression, object?[]? filterValues);
}