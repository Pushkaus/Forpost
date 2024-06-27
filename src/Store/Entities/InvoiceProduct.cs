using System.ComponentModel.DataAnnotations.Schema;

namespace Forpost.Store.Entities;

public sealed class InvoiceProduct
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = null!;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
}