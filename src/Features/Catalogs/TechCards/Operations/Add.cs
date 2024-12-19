using Forpost.Domain.Catalogs.TechCards.Operations;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.Operations;

internal sealed class AddOperationCommandHandler : ICommandHandler<AddOperationCommand, Guid>
{
    private readonly IOperationDomainRepository _domainRepository;

    public AddOperationCommandHandler(IOperationDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<Guid> Handle(AddOperationCommand request, CancellationToken cancellationToken)
    {
        var operation = Operation.Create(
            request.Name,
            request.Description,
            OperationType.FromValue(request.OperationTypeValue));
        
        var operationId = _domainRepository.Add(operation);
        
        return await Task.FromResult(operationId);
    }
}

public sealed record AddOperationCommand(string Name, string? Description, int OperationTypeValue) : ICommand<Guid>;