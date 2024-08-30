using Forpost.Common;
using Forpost.Domain.ProductCreating.Issue;
using MediatR;

namespace Forpost.Features.ProductCreating.Issues;

internal sealed class LauncherIssueCommandHandler: IRequestHandler<LaunchIssueCommand>
{
    private readonly IIssueDomainRepository _issueDomainRepository;

    public LauncherIssueCommandHandler(IIssueDomainRepository issueDomainRepository)
    {
        _issueDomainRepository = issueDomainRepository;
    }

    public async Task Handle(LaunchIssueCommand command, CancellationToken cancellationToken)
    {
        //TODO; Меняет статус продукта в разработке на "В работе"
        var issue = await _issueDomainRepository.GetByIdAsync(command.IssueId, cancellationToken);
        
        issue.EnsureFoundBy(issue => issue.Id, command.IssueId).Launch();
        
        if (issue.ExecutorId == null)
            throw new Exception("Невозможно запустить задачу без исполнителя.");
        
        _issueDomainRepository.Update(issue);
    }
}
public record LaunchIssueCommand(Guid IssueId) : IRequest;
