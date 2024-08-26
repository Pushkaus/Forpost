using Forpost.Common;
using Forpost.Domain.ProductCreating.Issue;
using MediatR;

namespace Forpost.Application.ProductCreating.Issues;

internal sealed class LauncherIssueCommandHandler: IRequestHandler<LaunchIssueCommand>
{
    private readonly IIssueRepository _issueRepository;

    public LauncherIssueCommandHandler(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public async Task Handle(LaunchIssueCommand command, CancellationToken cancellationToken)
    {
        //TODO; Меняет статус продукта в разработке на "В работе"
        var issue = await _issueRepository.GetByIdAsync(command.IssueId, cancellationToken);
        
        issue.EnsureFoundBy(issue => issue.Id, command.IssueId).Launch();
        
        if (issue.ExecutorId == null)
            throw new Exception("Невозможно запустить задачу без исполнителя.");
        
        _issueRepository.Update(issue);
    }
}
public record LaunchIssueCommand(Guid IssueId) : IRequest;
