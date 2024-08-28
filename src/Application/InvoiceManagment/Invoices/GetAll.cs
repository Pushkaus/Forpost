using Forpost.Domain.InvoiceManagement;
using MediatR;

namespace Forpost.Application.InvoiceManagment.Invoices;

internal sealed class GetAllInvoicesQueryHandler: IRequestHandler<GetAllInvoicesQuery, IReadOnlyCollection<Invoice>>
{
    private readonly IInvoiceRepository _invoiceRepository;

    public GetAllInvoicesQueryHandler(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public async Task<IReadOnlyCollection<Invoice>> Handle(GetAllInvoicesQuery request,
        CancellationToken cancellationToken)
    {
        return await _invoiceRepository.GetAllAsync(cancellationToken);
    }
}
public record GetAllInvoicesQuery() : IRequest<IReadOnlyCollection<Invoice>>;