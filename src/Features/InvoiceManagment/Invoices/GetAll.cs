using Forpost.Domain.InvoiceManagement;
using Mediator;

namespace Forpost.Features.InvoiceManagment.Invoices;

internal sealed class GetAllInvoicesQueryHandler: IQueryHandler<GetAllInvoicesQuery, IReadOnlyCollection<Invoice>>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;

    public GetAllInvoicesQueryHandler(IInvoiceDomainRepository invoiceDomainRepository)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
    }

    public async ValueTask<IReadOnlyCollection<Invoice>> Handle(GetAllInvoicesQuery request,
        CancellationToken cancellationToken)
    {
        return await _invoiceDomainRepository.GetAllAsync(cancellationToken);
    }
}
public record GetAllInvoicesQuery() : IQuery<IReadOnlyCollection<Invoice>>;