using Forpost.Domain.Catalogs.Contractors;
using Mediator;

namespace Forpost.Features.Catalogs.Contractors;

internal sealed class AddContractorCommandHandler : ICommandHandler<AddContractorCommand, Guid>
{
    private readonly IContractorDomainRepository _domainRepository;

    public AddContractorCommandHandler(IContractorDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public ValueTask<Guid> Handle(AddContractorCommand request, CancellationToken cancellationToken)
    {
        var contractor = Contractor.New(
            request.Name,
            request.INN,
            request.Country,
            request.City,
            ContractorType.FromValue(request.ContractorType),
            request.Description,
            request.DiscountLevel,
            request.LogisticInfo
        );

        var additionItemId = _domainRepository.Add(contractor);
        return ValueTask.FromResult(additionItemId);
    }
}

public sealed record AddContractorCommand(
    string Name,
    string INN,
    string Country,
    string City,
    string? Description,
    decimal? DiscountLevel,
    string? LogisticInfo,
    int ContractorType) : ICommand<Guid>;