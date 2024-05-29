namespace Forpost.Web.Contracts.OrderBlock
{
    public class OrderBlockResponse
    {
        public OrderBlockResponse() { } // Добавляем конструктор по умолчанию без аргументов

        public int Id { get; set; }
        public string? Klient { get; set; }
        public string? Account { get; set; }
        public string? Block { get; set; }
        public string? Amount { get; set; }
        public DateOnly? Deadline { get; set; }
    }
}
