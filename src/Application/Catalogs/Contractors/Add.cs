using AutoMapper;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Store.Postgres;
using MediatR;

namespace Forpost.Application.Catalogs.Contractors;

//TODO: вынести круды для каталогов в базовый класс
internal sealed class AddContractorCommandHandler : IRequestHandler<AddContractorCommand, Guid>
{
    private readonly IContractorRepository _repository;
    private readonly IMapper _mapper;
    private readonly ForpostContextPostgres _context;

    public AddContractorCommandHandler(IContractorRepository repository, IMapper mapper, ForpostContextPostgres context)
    {
        _repository = repository;
        _mapper = mapper;
        _context = context;
    }

    public async Task<Guid> Handle(AddContractorCommand request, CancellationToken cancellationToken)
    {
        var additionItemId = _repository.Add(_mapper.Map<Contractor>(request));
        return await Task.FromResult(additionItemId);
    }
}

public sealed record AddContractorCommand(string Name) : IRequest<Guid>;