using Forpost.Application.Contracts.Catalogs.Steps;
using Forpost.Common;
using Forpost.Domain.Catalogs.Steps;
using MediatR;

namespace Forpost.Application.Catalogs.Steps;

internal sealed class GetStepByIdQueryHandler : IRequestHandler<GetStepByIdQuery, StepWithSummary>
{
    private readonly IStepRepository _repository;

    private readonly IStepReadRepository _readRepository;

    public GetStepByIdQueryHandler(IStepRepository repository, IStepReadRepository readRepository)
    {
        _repository = repository;
        _readRepository = readRepository;
    }

    public async Task<StepWithSummary?> Handle(GetStepByIdQuery request, CancellationToken cancellationToken)
    {
        return await _readRepository.GetStepWithSummaryByIdAsync(request.Id, cancellationToken);
    }
}

public sealed record GetStepByIdQuery(Guid Id) : IRequest<StepWithSummary>;