namespace Forpost.Web.Contracts.Models.ProductOperations;

public class AddOperationDto
{
    public string ProductName { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal OperationTime { get; set; }
    public decimal Cost { get; set; }

}