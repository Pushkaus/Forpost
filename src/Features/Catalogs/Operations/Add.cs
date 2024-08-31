using AutoMapper;
using Forpost.Domain.Catalogs.Operations;
using Mediator;

namespace Forpost.Features.Catalogs.Operations;

//TODO: вынести круды для каталогов в базовый класс
internal sealed class AddOperationCommandHandler : ICommandHandler<AddOperationCommand, Guid>
{
    private readonly IOperationDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public AddOperationCommandHandler(IOperationDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public async ValueTask<Guid> Handle(AddOperationCommand request, CancellationToken cancellationToken)
    {
        var additionItemId = _domainRepository.Add(_mapper.Map<Operation>(request));
        return await Task.FromResult(additionItemId);
    }
}

public sealed record AddOperationCommand(string Name) : ICommand<Guid>;