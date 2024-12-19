using Forpost.Domain.Catalogs.TechCards.TechCardSteps;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.TechCardSteps;

internal sealed class GetTechCardStepByIdQueryHandler : IQueryHandler<GetTechCardStepByIdQuery, IReadOnlyCollection<TechCardStep>>
{
    private readonly ITechCardStepDomainRepository _domainRepository;

    public GetTechCardStepByIdQueryHandler(ITechCardStepDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<IReadOnlyCollection<TechCardStep>> Handle(GetTechCardStepByIdQuery request, CancellationToken cancellationToken)
    {
        return await _domainRepository.GetAllStepsByTechCardId(request.TechCardId, cancellationToken);
    }
}

public sealed record GetTechCardStepByIdQuery(Guid TechCardId) : IQuery<IReadOnlyCollection<TechCardStep>>;