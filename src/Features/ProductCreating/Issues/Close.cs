using Forpost.Common;
using Forpost.Domain.ProductCreating.Issue;
using Mediator;

namespace Forpost.Features.ProductCreating.Issues;

internal sealed class CloseIssueCommandHandler: ICommandHandler<CloseIssueCommand>
{
    private readonly IIssueDomainRepository _issueDomainRepository;

    private readonly ISender _sender;
    public CloseIssueCommandHandler(IIssueDomainRepository issueDomainRepository, ISender sender)
    {
        _issueDomainRepository = issueDomainRepository;
        _sender = sender;
    }

    public async ValueTask<Unit> Handle(CloseIssueCommand command, CancellationToken cancellationToken)
    {
        ///TODO; проверить, что текущее количество == целевому из производственного процесса
        var issue = await _issueDomainRepository.GetByIdAsync(command.Id, cancellationToken);
        if (issue.ExecutorId == Guid.Empty)
            throw new Exception("Невозможно завершить задачу без исполнителя");
        
        issue.EnsureFoundBy(issue => issue.Id, command.Id).Close();
        
        _issueDomainRepository.Update(issue);
        
        return Unit.Value;
    }
}
public record CloseIssueCommand(Guid Id) : ICommand;
