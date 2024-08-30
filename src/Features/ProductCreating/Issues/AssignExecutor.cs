using Forpost.Common;
using Forpost.Domain.ProductCreating.Issue;
using MediatR;

namespace Forpost.Features.ProductCreating.Issues;

internal sealed class AssignExecutorCommandHandler: IRequestHandler<AssignExecutorCommand>
{
    private readonly IIssueDomainRepository _issueDomainRepository;

    public AssignExecutorCommandHandler(IIssueDomainRepository issueDomainRepository)
    {
        _issueDomainRepository = issueDomainRepository;
    }

    public async Task Handle(AssignExecutorCommand command, CancellationToken cancellationToken)
    {
        var issue = await _issueDomainRepository.GetByIdAsync(command.IssueId, cancellationToken);
        
        issue.EnsureFoundBy(issue => issue.Id, command.IssueId).AssignExecutor(command.ExecutorId);

        _issueDomainRepository.Update(issue);
    }
}
public record AssignExecutorCommand(Guid IssueId, Guid ExecutorId): IRequest;