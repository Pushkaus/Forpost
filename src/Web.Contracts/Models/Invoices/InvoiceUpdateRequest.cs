namespace Forpost.Store.Repositories;

public class InvoiceUpdateRequest
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public string Contragent { get; set; }
    public string? Description { get; set; }
}