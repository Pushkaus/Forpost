using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Changes;
using Mediator;

namespace Forpost.Features.ChangeLogs;

internal sealed class
    GetChangeLogsByIdQueryHandler : IQueryHandler<GetChangeLogsByIdQuery, EntityPagedResult<ChangeHistoryModel>>
{
    private readonly IChangeHistoryReadRepository _changeHistoryReadRepository;

    public GetChangeLogsByIdQueryHandler(IChangeHistoryReadRepository changeHistoryReadRepository)
    {
        _changeHistoryReadRepository = changeHistoryReadRepository;
    }

    public async ValueTask<EntityPagedResult<ChangeHistoryModel>> Handle(GetChangeLogsByIdQuery query,
        CancellationToken cancellationToken) =>
        await _changeHistoryReadRepository.GetChangeLogsByIdAsync(query.Id, query.Filter, cancellationToken);
}

public record GetChangeLogsByIdQuery(Guid Id, ChangeLogFilter Filter) : IQuery<EntityPagedResult<ChangeHistoryModel>>;