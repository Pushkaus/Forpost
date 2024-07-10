namespace Forpost.Business.Models.SubProducts;

public class SubProductModel
{
    public Guid DaughterId { get; set; }
    public string DaughterName { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
}