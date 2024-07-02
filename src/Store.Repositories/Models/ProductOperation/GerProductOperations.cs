namespace Forpost.Store.Repositories.Models.ProductOperation;

public class GerProductOperations
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal? OperationTime { get; set; }
    public decimal? Cost { get; set; }
    public string ProductName { get; set; } // Дополнительное поле для имени продукта

}