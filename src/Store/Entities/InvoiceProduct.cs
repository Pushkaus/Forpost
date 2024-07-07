using System.ComponentModel.DataAnnotations.Schema;
using Forpost.Store.Contracts;

namespace Forpost.Store.Entities;

public sealed class InvoiceProduct: IEntity
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = null!;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
}