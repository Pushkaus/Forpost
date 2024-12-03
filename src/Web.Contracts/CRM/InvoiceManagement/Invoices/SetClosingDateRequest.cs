namespace Forpost.Web.Contracts.CRM.InvoiceManagement.Invoices;

public sealed class SetClosingDateRequest
{
    public DateTimeOffset ClosingDate { get; set; }
}