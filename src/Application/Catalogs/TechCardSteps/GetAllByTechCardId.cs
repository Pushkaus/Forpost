using Forpost.Common;
using Forpost.Domain.Catalogs.TechCardSteps;
using MediatR;

namespace Forpost.Application.Catalogs.TechCardSteps;

internal sealed class GetTechCardStepByIdQueryHandler : IRequestHandler<GetTechCardStepByIdQuery, IReadOnlyCollection<TechCardStep>>
{
    private readonly ITechCardStepRepository _repository;

    public GetTechCardStepByIdQueryHandler(ITechCardStepRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<TechCardStep>> Handle(GetTechCardStepByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllStepsByTechCardId(request.TechCardId, cancellationToken);
    }
}

public sealed record GetTechCardStepByIdQuery(Guid TechCardId) : IRequest<IReadOnlyCollection<TechCardStep>>;