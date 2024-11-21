using Forpost.Application.Contracts;
using Forpost.Application.Contracts.ChangeLogs;
using Forpost.Domain.ChangeLogs;
using Mediator;

namespace Forpost.Features.ChangeLogs;

internal sealed class
    GetChangeLogsByIdQueryHandler : IQueryHandler<GetChangeLogsByIdQuery, EntityPagedResult<ChangeLogModel>>
{
    private readonly IChangeLogReadRepository _changeLogReadRepository;

    public GetChangeLogsByIdQueryHandler(IChangeLogReadRepository changeLogReadRepository)
    {
        _changeLogReadRepository = changeLogReadRepository;
    }

    public async ValueTask<EntityPagedResult<ChangeLogModel>> Handle(GetChangeLogsByIdQuery query,
        CancellationToken cancellationToken) =>
        await _changeLogReadRepository.GetChangeLogsByIdAsync(query.Id, query.Filter, cancellationToken);
}

public record GetChangeLogsByIdQuery(Guid Id, ChangeLogFilter Filter) : IQuery<EntityPagedResult<ChangeLogModel>>;