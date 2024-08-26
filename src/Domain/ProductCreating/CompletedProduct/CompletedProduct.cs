using Forpost.Common.EntityAnnotations;
using Forpost.Common.EntityTemplates;

namespace Forpost.Domain.ProductCreating.CompletedProduct;

/// <summary>
/// Завершенный продукт
/// </summary>
public sealed class CompletedProduct : DomainEntity
{
    public Guid ProductId { get; set; }
    public Guid ManufacturingProcessId { get; set; }


    /// <summary>
    /// Номер счета, в который уйдет продукт
    /// </summary>
    public Guid? InvoiceId { get; set; }

    public Guid Id { get; set; }
}