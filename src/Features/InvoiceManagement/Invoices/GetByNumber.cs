using Forpost.Common;
using Forpost.Domain.InvoiceManagement;
using Mediator;

namespace Forpost.Features.InvoiceManagment.Invoices;

internal sealed class GetInvoiceByNumberQueryHandler: IQueryHandler<GetInvoiceByNumberQuery, Invoice>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    public GetInvoiceByNumberQueryHandler(IInvoiceDomainRepository invoiceDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
    }

    public async ValueTask<Invoice> Handle(GetInvoiceByNumberQuery request, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceDomainRepository.GetByNumberAsync(request.Number, cancellationToken);
        invoice.EnsureFoundBy(entity => entity.Number, request.Number);
        return invoice;
    }
}
public record GetInvoiceByNumberQuery(string Number): IQuery<Invoice>;