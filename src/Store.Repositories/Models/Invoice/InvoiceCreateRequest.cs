namespace Forpost.Store.Repositories;

public class InvoiceCreateRequest
{
    public InvoiceCreateRequest(string number, string contragent, string comment)
    {
        Number = number;
        Contragent = contragent;
        Comment = comment;
    }
    public Guid Id { get; set; }
    public string Number { get; set; }
    public string Contragent { get; set; }
    public string Comment { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
}