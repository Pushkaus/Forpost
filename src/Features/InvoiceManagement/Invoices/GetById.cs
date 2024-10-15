using Forpost.Common;
using Forpost.Domain.CRM.InvoiceManagement;
using Mediator;

namespace Forpost.Features.InvoiceManagement.Invoices;

internal sealed class GetInvoiceByIdQueryHandler: IQueryHandler<GetInvoiceByIdQuery, Invoice>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    public GetInvoiceByIdQueryHandler(IInvoiceDomainRepository invoiceDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
    }

    public async ValueTask<Invoice> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceDomainRepository.GetByIdAsync(request.Id, cancellationToken);
        invoice.EnsureFoundBy(entity => entity.Id, request.Id);
        return invoice;
    }
}
public record GetInvoiceByIdQuery(Guid Id): IQuery<Invoice>;