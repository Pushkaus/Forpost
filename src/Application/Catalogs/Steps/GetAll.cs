using Forpost.Domain.Catalogs.Steps;
using MediatR;

namespace Forpost.Application.Catalogs.Steps;

internal sealed class GetAllStepsQueryHandler :
    IRequestHandler<GetAllStepsQuery, IReadOnlyCollection<Step>>
{
    private readonly IStepRepository _repository;

    public GetAllStepsQueryHandler(IStepRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<Step>> Handle(GetAllStepsQuery request,
        CancellationToken cancellationToken) => await _repository.GetAllAsync(cancellationToken);
}

public sealed record GetAllStepsQuery : IRequest<IReadOnlyCollection<Step>>;