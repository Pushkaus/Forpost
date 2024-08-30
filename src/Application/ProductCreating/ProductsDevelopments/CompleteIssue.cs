using MediatR;

namespace Forpost.Application.ProductCreating.ProductsDevelopments;

internal sealed class CompleteIssue
{
    
}
public record CompleteIssueCommand(Guid productDevelopmentId) : IRequest<CompleteIssueCommand>;