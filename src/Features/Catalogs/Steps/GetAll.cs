using Forpost.Domain.Catalogs.Steps;
using Mediator;

namespace Forpost.Features.Catalogs.Steps;

internal sealed class GetAllStepsQueryHandler :
    IQueryHandler<GetAllStepsQuery, (IReadOnlyCollection<Step> Steps, int TotalCount)>
{
    private readonly IStepDomainRepository _domainRepository;

    public GetAllStepsQueryHandler(IStepDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<(IReadOnlyCollection<Step>, int)> Handle(GetAllStepsQuery request,
        CancellationToken cancellationToken)
        => await _domainRepository.GetAllAsync(request.FilterExpression, request.FilterValues, cancellationToken,
            request.Skip, request.Limit);
}

public sealed record GetAllStepsQuery(
    string? FilterExpression,
    object?[]? FilterValues,
    int Skip,
    int Limit) : IQuery<(IReadOnlyCollection<Step> Steps, int TotalCount)>;