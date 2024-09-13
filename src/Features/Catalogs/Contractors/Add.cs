using AutoMapper;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Store.Postgres;
using Mediator;

namespace Forpost.Features.Catalogs.Contractors;

//TODO: вынести круды для каталогов в базовый класс
internal sealed class AddContractorCommandHandler : ICommandHandler<AddContractorCommand, Guid>
{
    private readonly IContractorDomainRepository _domainRepository;

    public AddContractorCommandHandler(IContractorDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<Guid> Handle(AddContractorCommand request, CancellationToken cancellationToken)
    {
        var additionItemId = _domainRepository.Add(Contractor.New(request.Name));
        return await ValueTask.FromResult(additionItemId);
    }
}

public sealed record AddContractorCommand(string Name) : ICommand<Guid>;