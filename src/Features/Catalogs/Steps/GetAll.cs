using Forpost.Domain.Catalogs.Steps;
using Mediator;

namespace Forpost.Features.Catalogs.Steps;

internal sealed class GetAllStepsQueryHandler :
    IQueryHandler<GetAllStepsQuery, IReadOnlyCollection<Step>>
{
    private readonly IStepDomainRepository _domainRepository;

    public GetAllStepsQueryHandler(IStepDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<IReadOnlyCollection<Step>> Handle(GetAllStepsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllStepsQuery : IQuery<IReadOnlyCollection<Step>>;