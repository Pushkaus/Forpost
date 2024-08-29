using Forpost.Domain.InvoiceManagement;
using MediatR;

namespace Forpost.Application.InvoiceManagment.Invoices;

internal sealed class GetAllInvoicesQueryHandler: IRequestHandler<GetAllInvoicesQuery, IReadOnlyCollection<Invoice>>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    public GetAllInvoicesQueryHandler(IInvoiceDomainRepository invoiceDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
    }

    public async Task<IReadOnlyCollection<Invoice>> Handle(GetAllInvoicesQuery request,
        CancellationToken cancellationToken)
    {
        return await _invoiceDomainRepository.GetAllAsync(cancellationToken);
    }
}
public record GetAllInvoicesQuery() : IRequest<IReadOnlyCollection<Invoice>>;