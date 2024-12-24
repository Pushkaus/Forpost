namespace Forpost.Web.Contracts.Crm.InvoiceManagement.Invoices;

public sealed class SetClosingDateRequest
{
    public DateTimeOffset ClosingDate { get; set; }
}