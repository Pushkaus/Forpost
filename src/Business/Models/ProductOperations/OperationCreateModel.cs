namespace Forpost.Business.Models.ProductOperations;

public class OperationCreateModel
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal? OperationTime { get; set; }
    public decimal? Cost { get; set; }
}