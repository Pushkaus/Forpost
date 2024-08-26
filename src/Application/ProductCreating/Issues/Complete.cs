using Forpost.Common;
using Forpost.Domain.ProductCreating.Issue;
using MediatR;

namespace Forpost.Application.ProductCreating.Issues;

internal sealed class CompletedIssueCommandHandler: IRequestHandler<CompletedIssueCommand>
{
    private readonly IIssueRepository _issueRepository;

    public CompletedIssueCommandHandler(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public async Task Handle(CompletedIssueCommand command, CancellationToken cancellationToken)
    {
        var issue = await _issueRepository.GetByIdAsync(command.Id, cancellationToken);
        if (issue.ExecutorId == Guid.Empty)
            throw new Exception("Невозможно завершить задачу без исполнителя");
        
        issue.EnsureFoundBy(issue => issue.Id, command.Id).Complete();
        
        _issueRepository.Update(issue);
    }
}
public record CompletedIssueCommand(Guid Id) : IRequest;
