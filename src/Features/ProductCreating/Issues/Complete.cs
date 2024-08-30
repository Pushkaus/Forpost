using Forpost.Common;
using Forpost.Domain.ProductCreating.Issue;
using MediatR;

namespace Forpost.Features.ProductCreating.Issues;

internal sealed class CompletedIssueCommandHandler: IRequestHandler<CompletedIssueCommand>
{
    private readonly IIssueDomainRepository _issueDomainRepository;

    public CompletedIssueCommandHandler(IIssueDomainRepository issueDomainRepository)
    {
        _issueDomainRepository = issueDomainRepository;
    }

    public async Task Handle(CompletedIssueCommand command, CancellationToken cancellationToken)
    {
        var issue = await _issueDomainRepository.GetByIdAsync(command.Id, cancellationToken);
        if (issue.ExecutorId == Guid.Empty)
            throw new Exception("Невозможно завершить задачу без исполнителя");
        
        issue.EnsureFoundBy(issue => issue.Id, command.Id).Complete();
        
        _issueDomainRepository.Update(issue);
    }
}
public record CompletedIssueCommand(Guid Id) : IRequest;
