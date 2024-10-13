namespace Forpost.Application.Contracts.InvoiceManagment.CompositionInvoices;

public sealed class CompositionInvoiceModel
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public string Number { get; set; } = null!;
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public Guid CompletedProductId { get; set; }
    public Guid ProductDevelopmentId { get; set; }
    public string SerialNumber { get; set; } = null!;
}