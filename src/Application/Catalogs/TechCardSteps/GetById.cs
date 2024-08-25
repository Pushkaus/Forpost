using Forpost.Common;
using Forpost.Domain.Catalogs.TechCardSteps;
using MediatR;

namespace Forpost.Application.Catalogs.TechCardSteps;

internal sealed class GetTechCardStepByIdQueryHandler : IRequestHandler<GetTechCardStepByIdQuery, TechCardStep>
{
    private readonly ITechCardStepRepository _repository;

    public GetTechCardStepByIdQueryHandler(ITechCardStepRepository repository)
    {
        _repository = repository;
    }

    public async Task<TechCardStep> Handle(GetTechCardStepByIdQuery request, CancellationToken cancellationToken)
    {
        var techCardStep = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return techCardStep.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetTechCardStepByIdQuery(Guid Id) : IRequest<TechCardStep>;