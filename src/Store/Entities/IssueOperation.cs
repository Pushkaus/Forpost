using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public class IssueOperation: IEntity
{
    public Guid Id { get; set; }
    public Guid IssueId { get; set; }
    public Guid ProductId { get; set; }
    public Guid OperationId { get; set; }
   
}