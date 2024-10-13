using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.CRM.PriceLists;

public interface IPriceListReadRepository : IApplicationReadRepository
{
    public Task<(IReadOnlyCollection<PriceListModel> PriceList, int TotalCount)> GetAll(PriceListFilter filter,
        CancellationToken cancellationToken);
}