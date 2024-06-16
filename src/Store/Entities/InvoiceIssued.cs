namespace Forpost.Store.Entities
{
    public class InvoiceIssued
    {
        public int Id { get; set; }
        public int InvoiceNumber { get; set; }
        public string CounterAgent { get; set; }
        public string Commentary { get; set; }
        public DateTime DateUp { get; set; } // Дата, до которой должен быть сделан заказ
        public DateTime DateOfAddition { get; set; }
        public int PaymentPercentage { get; set; }
        public bool Payment { get; set; }
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>(); // Список позиций оборудования
    }
}
