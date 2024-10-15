using Forpost.Application.Contracts.ProductCreating.Issues;
using Forpost.Common;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using Mediator;

namespace Forpost.Features.ProductCreating.ManufacturingProcesses;

internal sealed class CompletedManufacturingProcessCommandHandler: ICommandHandler<CompletionManufacturingProcessCommand>
{
    private readonly IManufacturingProcessDomainRepository _manufacturingProcessDomainRepository;
    private readonly IIssueReadRepository _issueReadRepository;

    public CompletedManufacturingProcessCommandHandler(IManufacturingProcessDomainRepository manufacturingProcessDomainRepository, IIssueReadRepository issueReadRepository)
    {
        _manufacturingProcessDomainRepository = manufacturingProcessDomainRepository;
        _issueReadRepository = issueReadRepository;
    }

    public async ValueTask<Unit> Handle(CompletionManufacturingProcessCommand command, CancellationToken cancellationToken)
    {
        var issues = await _issueReadRepository.GetAllFromManufacturingProcessId(command.Id, cancellationToken);

        if (issues.Any(issue => issue.Status != IssueStatusModel.Completed))
        {
            throw new Exception("Не все задачи завершены");
        }
        
        var manufacturingProcess = await _manufacturingProcessDomainRepository.GetByIdAsync(command.Id, cancellationToken);
        
        manufacturingProcess.EnsureFoundBy(entity => entity.Id, command.Id).Complete();
        
        _manufacturingProcessDomainRepository.Update(manufacturingProcess);
        return Unit.Value;
    }
}

public record CompletionManufacturingProcessCommand(Guid Id) : ICommand;