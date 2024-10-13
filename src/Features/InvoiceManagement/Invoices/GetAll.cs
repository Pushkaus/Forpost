using Forpost.Application.Contracts.InvoiceManagment.Invoices;
using Mediator;

namespace Forpost.Features.InvoiceManagement.Invoices;

internal sealed class GetAllInvoicesQueryHandler :
    IQueryHandler<GetAllInvoicesQuery, (IReadOnlyCollection<InvoiceModel> Invoices, int TotalCount)>
{
    private readonly IInvoiceReadRepository _invoiceReadRepository;

    public GetAllInvoicesQueryHandler(IInvoiceReadRepository invoiceReadRepository)
    {
        _invoiceReadRepository = invoiceReadRepository;
    }

    public async ValueTask<(IReadOnlyCollection<InvoiceModel> Invoices, int TotalCount)> Handle(GetAllInvoicesQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _invoiceReadRepository.GetAll(cancellationToken, request.Skip, request.Limit,
            request.FilterExpression, request.FilterValues);
        return (result.Invoices, result.TotalCount);
    }
}

public record GetAllInvoicesQuery(
    string? FilterExpression,
    object?[]? FilterValues,
    int Skip,
    int Limit) : IQuery<(IReadOnlyCollection<InvoiceModel> Invoices, int TotalCount)>;