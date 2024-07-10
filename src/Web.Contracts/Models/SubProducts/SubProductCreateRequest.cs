namespace Forpost.Web.Contracts.Models.SubProducts;

public class SubProductCreateRequest
{
    public Guid ParentId { get; set; }
    public Guid DaughterId { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
}