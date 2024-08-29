namespace Forpost.Web.Contracts.Catalogs.Operations;

public class OperationCreateRequest
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal? OperationTime { get; set; }
    public decimal? Cost { get; set; }
}