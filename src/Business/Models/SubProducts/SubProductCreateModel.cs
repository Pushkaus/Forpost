namespace Forpost.Business.Models.SubProducts;

public class SubProductCreateModel
{
    public Guid ParentId { get; set; }
    public Guid DaughterId { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
}