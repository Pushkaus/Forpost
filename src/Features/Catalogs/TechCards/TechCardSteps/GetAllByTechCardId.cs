using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.TechCards.TechCardSteps;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.TechCardSteps;

internal sealed class
    GetTechCardStepByIdQueryHandler : IQueryHandler<GetTechCardStepByIdQuery, EntityPagedResult<TechCardStepModel>>
{
    private readonly ITechCardStepReadRepository _techCardStepReadRepository;

    public GetTechCardStepByIdQueryHandler(ITechCardStepReadRepository techCardStepReadRepository)
    {
        _techCardStepReadRepository = techCardStepReadRepository;
    }

    public async ValueTask<EntityPagedResult<TechCardStepModel>> Handle(GetTechCardStepByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _techCardStepReadRepository.GetTechCardStepsAsync(request.TechCardId, request.Filter,
            cancellationToken);
    }
}

public sealed record GetTechCardStepByIdQuery(Guid TechCardId, TechCardStepFilter Filter)
    : IQuery<EntityPagedResult<TechCardStepModel>>;