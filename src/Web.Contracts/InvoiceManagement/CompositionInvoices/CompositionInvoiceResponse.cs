namespace Forpost.Web.Contracts.InvoiceManagement.CompositionInvoices;

public sealed class CompositionInvoiceResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
}