using Forpost.Domain.Catalogs.TechCardSteps;
using Mediator;

namespace Forpost.Features.Catalogs.TechCardSteps;

internal sealed class GetAllTechCardStepsQueryHandler :
    IQueryHandler<GetAllTechCardStepsQuery, IReadOnlyCollection<TechCardStep>>
{
    private readonly ITechCardStepDomainRepository _domainRepository;

    public GetAllTechCardStepsQueryHandler(ITechCardStepDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<IReadOnlyCollection<TechCardStep>> Handle(GetAllTechCardStepsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllTechCardStepsQuery : IQuery<IReadOnlyCollection<TechCardStep>>;