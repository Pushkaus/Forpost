using Forpost.Application.Contracts.Catalogs.TechCards.Steps;
using Forpost.Common;
using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Catalogs.TechCards.Steps;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.Steps;

internal sealed class GetStepByIdQueryHandler : IQueryHandler<GetStepByIdQuery, StepModel>
{
    private readonly IStepReadRepository _stepReadRepository;
    
    public GetStepByIdQueryHandler(IStepReadRepository stepReadRepository)
    {
        _stepReadRepository = stepReadRepository;
    }

    public async ValueTask<StepModel> Handle(GetStepByIdQuery request, CancellationToken cancellationToken)
    {
        var step = await _stepReadRepository.GetStepByIdAsync(request.Id, cancellationToken);
        if (step == null) throw ForpostErrors.NotFound<Step>(request.Id);
        return step;
    }
}

public sealed record GetStepByIdQuery(Guid Id) : IQuery<StepModel>;