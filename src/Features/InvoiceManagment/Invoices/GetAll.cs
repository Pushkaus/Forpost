using Forpost.Domain.InvoiceManagement;
using Mediator;

namespace Forpost.Features.InvoiceManagment.Invoices;

internal sealed class GetAllInvoicesQueryHandler :
    IQueryHandler<GetAllInvoicesQuery, (IReadOnlyCollection<Invoice> Invoices, int TotalCount)>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    public GetAllInvoicesQueryHandler(IInvoiceDomainRepository invoiceDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
    }

    public async ValueTask<(IReadOnlyCollection<Invoice> Invoices, int TotalCount)> Handle(GetAllInvoicesQuery request,
        CancellationToken cancellationToken)
    {
        var invoices = await _invoiceDomainRepository.GetAllAsync(request.FilterExpression, request.FilterValues,
            cancellationToken, request.Skip, request.Limit);
        return (invoices);
    }
}

public record GetAllInvoicesQuery(
    string? FilterExpression,
    object?[]? FilterValues,
    int Skip,
    int Limit) : IQuery<(IReadOnlyCollection<Invoice> Invoices, int TotalCount)>;