using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public class ProductDetails: IEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid ManufacturingProcessDetailsId { get; set; }
    /// <summary>
    /// Серийный номер продукта
    /// </summary>
    public int SerialNumber { get; set; }
    public Product Product { get; set; }
    public ManufacturingProcess ManufacturingProcess { get; set; }
}