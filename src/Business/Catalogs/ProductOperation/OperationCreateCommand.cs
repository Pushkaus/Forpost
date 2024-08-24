namespace Forpost.Business.Catalogs.ProductOperation;

public class OperationCreateCommand
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal? OperationTime { get; set; }
    public decimal? Cost { get; set; }
}