using Forpost.Domain.Crm.IssueHistory;
using Forpost.Domain.ProductCreating.Issue.Events;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class ProductCompletedNotificationHandler: INotificationHandler<ProductCompleted>
{
    private readonly IIssueHistoryDomainRepository _issueHistoryDomainRepository;

    public ProductCompletedNotificationHandler(IIssueHistoryDomainRepository issueHistoryDomainRepository)
    {
        _issueHistoryDomainRepository = issueHistoryDomainRepository;
    }

    public ValueTask Handle(ProductCompleted notification, CancellationToken cancellationToken)
    {
        var issueHistory = new IssueHistory
        {
            ProductDevelopmentId = notification.ProductDevelopmentId,
            IssueId = notification.IssueId,
            CompletionDate = TimeProvider.System.GetUtcNow(),
            ExecutorId = notification.ExecutorId,
            ResponsibleId = notification.ResponsibleId,
        };
        _issueHistoryDomainRepository.Add(issueHistory);
        return ValueTask.CompletedTask;
    }
}