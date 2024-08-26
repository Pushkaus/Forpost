using Forpost.Domain.Catalogs.TechCardSteps;
using MediatR;

namespace Forpost.Application.Catalogs.TechCardSteps;

internal sealed class GetAllTechCardStepsQueryHandler :
    IRequestHandler<GetAllTechCardStepsQuery, IReadOnlyCollection<TechCardStep>>
{
    private readonly ITechCardStepRepository _repository;

    public GetAllTechCardStepsQueryHandler(ITechCardStepRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<TechCardStep>> Handle(GetAllTechCardStepsQuery request,
        CancellationToken cancellationToken) => await _repository.GetAllAsync(cancellationToken);
}

public sealed record GetAllTechCardStepsQuery : IRequest<IReadOnlyCollection<TechCardStep>>;