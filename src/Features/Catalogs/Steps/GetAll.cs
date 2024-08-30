using Forpost.Domain.Catalogs.Steps;
using MediatR;

namespace Forpost.Features.Catalogs.Steps;

internal sealed class GetAllStepsQueryHandler :
    IRequestHandler<GetAllStepsQuery, IReadOnlyCollection<Step>>
{
    private readonly IStepDomainRepository _domainRepository;

    public GetAllStepsQueryHandler(IStepDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<IReadOnlyCollection<Step>> Handle(GetAllStepsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllStepsQuery : IRequest<IReadOnlyCollection<Step>>;