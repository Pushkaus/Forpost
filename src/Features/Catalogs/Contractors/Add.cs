using AutoMapper;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Store.Postgres;
using Mediator;

namespace Forpost.Features.Catalogs.Contractors;

//TODO: вынести круды для каталогов в базовый класс
internal sealed class AddContractorCommandHandler : ICommandHandler<AddContractorCommand, Guid>
{
    private readonly IContractorDomainRepository _domainRepository;
    private readonly IMapper _mapper;
    private readonly ForpostContextPostgres _context;

    public AddContractorCommandHandler(IContractorDomainRepository domainRepository, IMapper mapper, ForpostContextPostgres context)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
        _context = context;
    }

    public async ValueTask<Guid> Handle(AddContractorCommand request, CancellationToken cancellationToken)
    {
        var additionItemId = _domainRepository.Add(Contractor.New(request.Name));
        return await ValueTask.FromResult(additionItemId);
    }
}

public sealed record AddContractorCommand(string Name) : ICommand<Guid>;