using Forpost.Store.Contracts;

namespace Forpost.Store.Repositories.Models.ProductOperation;

public class CreateOperationOnProduct
{
    public Guid ProductId;
    public string OperationName;
    public string? Description;
    public decimal? OperationTime;
    public decimal? Cost;
    public DateTimeOffset CreatedAt;
    public Guid CreatedById;
    public DateTimeOffset UpdatedAt;
    public Guid UpdatedById;

}