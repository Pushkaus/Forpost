using Forpost.Common;
using Forpost.Domain.Catalogs.Steps;
using Mediator;

namespace Forpost.Features.Catalogs.Steps;

internal sealed class GetStepByIdQueryHandler : IQueryHandler<GetStepByIdQuery, Step>
{
    private readonly IStepDomainRepository _domainRepository;

    public GetStepByIdQueryHandler(IStepDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<Step> Handle(GetStepByIdQuery request, CancellationToken cancellationToken)
    {
        var step = await _domainRepository.GetByIdAsync(request.Id, cancellationToken);
        return step.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetStepByIdQuery(Guid Id) : IQuery<Step>;