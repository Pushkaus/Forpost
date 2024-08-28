using Forpost.Common;
using Forpost.Domain.InvoiceManagement;
using MediatR;

namespace Forpost.Application.InvoiceManagment.Invoices;

internal sealed class GetInvoiceByIdQueryHandler: IRequestHandler<GetInvoiceByIdQuery, Invoice>
{
    private readonly IInvoiceRepository _invoiceRepository;

    public GetInvoiceByIdQueryHandler(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public async Task<Invoice> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceRepository.GetByIdAsync(request.Id, cancellationToken);
        invoice.EnsureFoundBy(entity => entity.Id, request.Id);
        return invoice;
    }
}
public record GetInvoiceByIdQuery(Guid Id): IRequest<Invoice>;