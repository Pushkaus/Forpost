using Forpost.Application.Contracts.CRM.InvoiceManagement.Invoices;
using Mediator;

namespace Forpost.Features.CRM.InvoiceManagement.Invoices;

internal sealed class GetInvoiceByIdQueryHandler: IQueryHandler<GetInvoiceByIdQuery, InvoiceModel?>
{
    private readonly IInvoiceReadRepository _invoiceReadRepository;

    public GetInvoiceByIdQueryHandler(IInvoiceReadRepository invoiceReadRepository)
    {
        _invoiceReadRepository = invoiceReadRepository;
    }

    public async ValueTask<InvoiceModel?> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken) 
        => await _invoiceReadRepository.GetByIdAsync(request.Id, cancellationToken);
}
public record GetInvoiceByIdQuery(Guid Id): IQuery<InvoiceModel?>;