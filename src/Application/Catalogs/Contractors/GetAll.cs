using Forpost.Domain.Catalogs.Contractors;
using MediatR;

namespace Forpost.Application.Catalogs.Contractors;

internal sealed class GetAllContractorsQueryHandler :
    IRequestHandler<GetAllContractorsQuery, IReadOnlyCollection<Contractor>>
{
    private readonly IContractorRepository _repository;

    public GetAllContractorsQueryHandler(IContractorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<Contractor>> Handle(GetAllContractorsQuery request,
        CancellationToken cancellationToken) => await _repository.GetAllAsync(cancellationToken);
}

public sealed record GetAllContractorsQuery : IRequest<IReadOnlyCollection<Contractor>>;