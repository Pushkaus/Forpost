using Forpost.Common;
using Forpost.Domain.Catalogs.Steps;
using MediatR;

namespace Forpost.Application.Catalogs.Steps;

internal sealed class GetStepByIdQueryHandler : IRequestHandler<GetStepByIdQuery, Step>
{
    private readonly IStepRepository _repository;

    public GetStepByIdQueryHandler(IStepRepository repository)
    {
        _repository = repository;
    }

    public async Task<Step> Handle(GetStepByIdQuery request, CancellationToken cancellationToken)
    {
        var step = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return step.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetStepByIdQuery(Guid Id) : IRequest<Step>;