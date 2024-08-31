using Forpost.Common;
using Forpost.Domain.ProductCreating.Issue;
using Mediator;

namespace Forpost.Features.ProductCreating.Issues;

internal sealed class AssignExecutorCommandHandler: ICommandHandler<AssignExecutorCommand>
{
    private readonly IIssueDomainRepository _issueDomainRepository;

    public AssignExecutorCommandHandler(IIssueDomainRepository issueDomainRepository)
    {
        _issueDomainRepository = issueDomainRepository;
    }

    public async ValueTask<Unit> Handle(AssignExecutorCommand command, CancellationToken cancellationToken)
    {
        var issue = await _issueDomainRepository.GetByIdAsync(command.IssueId, cancellationToken);
        
        issue.EnsureFoundBy(issue => issue.Id, command.IssueId).AssignExecutor(command.ExecutorId);

        _issueDomainRepository.Update(issue);
        
        return Unit.Value;
    }
}
public record AssignExecutorCommand(Guid IssueId, Guid ExecutorId): ICommand;