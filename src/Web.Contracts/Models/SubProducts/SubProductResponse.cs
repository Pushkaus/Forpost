namespace Forpost.Web.Contracts.Models.SubProducts;

public class SubProductResponse
{
    public Guid DaughterId { get; set; }
    public string DaughterName { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal Quantity { get; set; }
}