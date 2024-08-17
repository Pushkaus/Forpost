using System.ComponentModel.DataAnnotations.Schema;
using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;
/// <summary>
/// Состав счета
/// </summary>
public sealed class InvoiceProduct: IEntity
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}