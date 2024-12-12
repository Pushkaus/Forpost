using Forpost.Application.Contracts;
using Forpost.Application.Contracts.CRM.InvoiceManagement.Invoices;
using Mediator;

namespace Forpost.Features.CRM.InvoiceManagement.Invoices;

internal sealed class GetAllInvoicesQueryHandler :
    IQueryHandler<GetAllInvoicesQuery, EntityPagedResult<InvoiceModel>>
{
    private readonly IInvoiceReadRepository _invoiceReadRepository;

    public GetAllInvoicesQueryHandler(IInvoiceReadRepository invoiceReadRepository)
    {
        _invoiceReadRepository = invoiceReadRepository;
    }

    public async ValueTask<EntityPagedResult<InvoiceModel>> Handle(
        GetAllInvoicesQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _invoiceReadRepository.GetAllAsync(request.Filter, cancellationToken);
        return result;
    }
}

public record GetAllInvoicesQuery(InvoiceFilter Filter) : IQuery<EntityPagedResult<InvoiceModel>>;