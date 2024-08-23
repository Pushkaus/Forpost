using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Business.Models.ProductDevelopment;

public sealed class ProductDevelopmentCreateModel
{
    public Guid ProductId { get; set; }
    public Guid ManufacturingProcessId { get; set; }
    public ProductStatus Status { get; set; }
    public Guid Id { get; set; }
}