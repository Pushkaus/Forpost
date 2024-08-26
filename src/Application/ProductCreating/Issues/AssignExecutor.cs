using Forpost.Common;
using Forpost.Domain.ProductCreating.Issue;
using MediatR;

namespace Forpost.Application.ProductCreating.Issues;

internal sealed class AssignExecutorCommandHandler: IRequestHandler<AssignExecutorCommand>
{
    private readonly IIssueRepository _issueRepository;

    public AssignExecutorCommandHandler(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public async Task Handle(AssignExecutorCommand command, CancellationToken cancellationToken)
    {
        var issue = await _issueRepository.GetByIdAsync(command.IssueId, cancellationToken);
        
        issue.EnsureFoundBy(issue => issue.Id, command.IssueId).AssignExecutor(command.ExecutorId);

        _issueRepository.Update(issue);
    }
}
public record AssignExecutorCommand(Guid IssueId, Guid ExecutorId): IRequest;