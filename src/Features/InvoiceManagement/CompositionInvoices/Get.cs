using Forpost.Application.Contracts.InvoiceManagment.CompositionInvoices;
using Forpost.Features.InvoiceManagment.InvoiceProducts;
using Mediator;

namespace Forpost.Features.InvoiceManagment.CompositionInvoices;

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