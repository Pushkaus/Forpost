using Forpost.Application.Contracts.Issues;
using Forpost.Common;
using Forpost.Domain.ProductCreating.ManufacturingProcesses;
using MediatR;

namespace Forpost.Application.ProductCreating.ManufacturingProcesses;

internal sealed class CompletedManufacturingProcessCommandHandler: IRequestHandler<CompletionManufacturingProcessCommand>
{
    private readonly IManufacturingProcessRepository _manufacturingProcessRepository;
    private readonly IIssueReadRepository _issueReadRepository;

    public CompletedManufacturingProcessCommandHandler(IManufacturingProcessRepository manufacturingProcessRepository, IIssueReadRepository issueReadRepository)
    {
        _manufacturingProcessRepository = manufacturingProcessRepository;
        _issueReadRepository = issueReadRepository;
    }

    public async Task Handle(CompletionManufacturingProcessCommand command, CancellationToken cancellationToken)
    {
        var issues = await _issueReadRepository.GetAllFromManufacturingProcessId(command.Id, cancellationToken);

        if (issues.Any(issue => issue.Status != IssueStatusModel.Completed))
        {
            throw new Exception("Не все задачи завершены");
        }
        
        var manufacturingProcess = await _manufacturingProcessRepository.GetByIdAsync(command.Id, cancellationToken);
        
        manufacturingProcess.EnsureFoundBy(entity => entity.Id, command.Id).Complete();
        
        _manufacturingProcessRepository.Update(manufacturingProcess);
    }
}

public record CompletionManufacturingProcessCommand(Guid Id) : IRequest;