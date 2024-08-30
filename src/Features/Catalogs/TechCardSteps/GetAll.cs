using Forpost.Domain.Catalogs.TechCardSteps;
using MediatR;

namespace Forpost.Features.Catalogs.TechCardSteps;

internal sealed class GetAllTechCardStepsQueryHandler :
    IRequestHandler<GetAllTechCardStepsQuery, IReadOnlyCollection<TechCardStep>>
{
    private readonly ITechCardStepDomainRepository _domainRepository;

    public GetAllTechCardStepsQueryHandler(ITechCardStepDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<IReadOnlyCollection<TechCardStep>> Handle(GetAllTechCardStepsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllTechCardStepsQuery : IRequest<IReadOnlyCollection<TechCardStep>>;