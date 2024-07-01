namespace Forpost.Web.Contracts;

public class ProductOnStorage
{
        public string ProductName { get; set; }
        public string StorageName { get; set; }
        public decimal Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
}