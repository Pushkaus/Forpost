using Forpost.Common;
using Forpost.Domain.InvoiceManagement;
using MediatR;

namespace Forpost.Features.InvoiceManagment.Invoices;

internal sealed class GetInvoiceByNumberQueryHandler: IRequestHandler<GetInvoiceByNumberQuery, Invoice>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    public GetInvoiceByNumberQueryHandler(IInvoiceDomainRepository invoiceDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
    }

    public async Task<Invoice> Handle(GetInvoiceByNumberQuery request, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceDomainRepository.GetByNumberAsync(request.Number, cancellationToken);
        invoice.EnsureFoundBy(entity => entity.Number, request.Number);
        return invoice;
    }
}
public record GetInvoiceByNumberQuery(string Number): IRequest<Invoice>;