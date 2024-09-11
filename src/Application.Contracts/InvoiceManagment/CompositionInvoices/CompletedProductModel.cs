namespace Forpost.Application.Contracts.InvoiceManagment.CompositionInvoice;

public sealed class CompletedProductModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid ProductId { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
}