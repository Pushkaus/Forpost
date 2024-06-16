namespace Forpost.Store.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public string NameDevice { get; set; }
        public int Quantity { get; set; }
        public int InvoiceIssuedId { get; set; }
        public InvoiceIssued InvoiceIssued { get; set; }
    }
}
