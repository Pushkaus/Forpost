using Forpost.Domain.Catalogs.TechCardSteps;
using MediatR;

namespace Forpost.Features.Catalogs.TechCardSteps;

internal sealed class GetTechCardStepByIdQueryHandler : IRequestHandler<GetTechCardStepByIdQuery, IReadOnlyCollection<TechCardStep>>
{
    private readonly ITechCardStepDomainRepository _domainRepository;

    public GetTechCardStepByIdQueryHandler(ITechCardStepDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<IReadOnlyCollection<TechCardStep>> Handle(GetTechCardStepByIdQuery request, CancellationToken cancellationToken)
    {
        return await _domainRepository.GetAllStepsByTechCardId(request.TechCardId, cancellationToken);
    }
}

public sealed record GetTechCardStepByIdQuery(Guid TechCardId) : IRequest<IReadOnlyCollection<TechCardStep>>;