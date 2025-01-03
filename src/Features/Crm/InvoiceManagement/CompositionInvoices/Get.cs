using Forpost.Application.Contracts.CRM.InvoiceManagement.CompositionInvoices;
using Mediator;

namespace Forpost.Features.Crm.InvoiceManagement.CompositionInvoices;

internal sealed class
    GetCompletedCompositionInvoiceQueryHandler : IQueryHandler<GetCompletedCompositionInvoiceQuery,
    IReadOnlyCollection<CompositionInvoiceModel>>
{
    private readonly ICompositionInvoiceReadRepository _compositionInvoiceReadRepository;

    public GetCompletedCompositionInvoiceQueryHandler(ICompositionInvoiceReadRepository compositionInvoiceReadRepository)
    {
        _compositionInvoiceReadRepository = compositionInvoiceReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<CompositionInvoiceModel>> Handle(GetCompletedCompositionInvoiceQuery query,
        CancellationToken cancellationToken)
    {
        return await _compositionInvoiceReadRepository.GetCompositionInvoice(query.InvoiceId, cancellationToken);
    }
}

public record GetCompletedCompositionInvoiceQuery(Guid InvoiceId) : IQuery<IReadOnlyCollection<CompositionInvoiceModel>>;