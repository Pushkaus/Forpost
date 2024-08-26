using Forpost.Common;
using Forpost.Domain.InvoiceManagment;
using Forpost.Domain.Sortout;
using MediatR;

namespace Forpost.Application.InvoiceManagment.Invoices;

internal sealed class GetInvoiceByNumberQueryHandler: IRequestHandler<GetInvoiceByNumberQuery, Invoice>
{
    private readonly IInvoiceRepository _invoiceRepository;

    public GetInvoiceByNumberQueryHandler(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public async Task<Invoice> Handle(GetInvoiceByNumberQuery request, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceRepository.GetByNumberAsync(request.Number, cancellationToken);
        invoice.EnsureFoundBy(entity => entity.Number, request.Number);
        return invoice;
    }
}
public record GetInvoiceByNumberQuery(string Number): IRequest<Invoice>;