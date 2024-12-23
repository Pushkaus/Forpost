using Forpost.Application.Contracts.CRM.PriceLists;
using Mediator;

namespace Forpost.Features.Crm.PriceLists;

internal sealed class GetAllPriceListQueryHandler : IQueryHandler<GetAllPriceListQuery, (
    IReadOnlyCollection<PriceListModel> PriceLists, int TotalCount)>
{
    private readonly IPriceListReadRepository _priceListReadRepository;

    public GetAllPriceListQueryHandler(IPriceListReadRepository priceListReadRepository)
    {
        _priceListReadRepository = priceListReadRepository;
    }

    public async ValueTask<(IReadOnlyCollection<PriceListModel> PriceLists, int TotalCount)> Handle(
        GetAllPriceListQuery query, CancellationToken cancellationToken) =>
        await _priceListReadRepository.GetAll(query.Filter, cancellationToken);
}

public record GetAllPriceListQuery(PriceListFilter Filter)
    : IQuery<(IReadOnlyCollection<PriceListModel> PriceLists, int TotalCount)>;