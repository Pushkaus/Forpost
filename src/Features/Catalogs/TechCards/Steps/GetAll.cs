using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.TechCards.Steps;
using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Catalogs.TechCards.Steps;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.Steps;

internal sealed class GetAllStepsQueryHandler :
    IQueryHandler<GetAllStepsQuery, EntityPagedResult<StepModel>>
{
    private readonly IStepReadRepository _stepReadRepository;

    public GetAllStepsQueryHandler(IStepReadRepository stepReadRepository)
    {
        _stepReadRepository = stepReadRepository;
    }

    public async ValueTask<EntityPagedResult<StepModel>> Handle(GetAllStepsQuery request,
        CancellationToken cancellationToken)
    {
        return await _stepReadRepository.GetAllStepsAsync(request.Filter, cancellationToken);
    }
}

public sealed record GetAllStepsQuery(StepFilter Filter) : IQuery<EntityPagedResult<StepModel>>;