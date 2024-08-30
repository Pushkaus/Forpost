using Forpost.Common;
using Forpost.Domain.InvoiceManagement;
using MediatR;

namespace Forpost.Features.InvoiceManagment.Invoices;

internal sealed class GetInvoiceByIdQueryHandler: IRequestHandler<GetInvoiceByIdQuery, Invoice>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    public GetInvoiceByIdQueryHandler(IInvoiceDomainRepository invoiceDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
    }

    public async Task<Invoice> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceDomainRepository.GetByIdAsync(request.Id, cancellationToken);
        invoice.EnsureFoundBy(entity => entity.Id, request.Id);
        return invoice;
    }
}
public record GetInvoiceByIdQuery(Guid Id): IRequest<Invoice>;