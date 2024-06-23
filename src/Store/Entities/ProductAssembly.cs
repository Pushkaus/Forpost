namespace Forpost.Store.Entities;

public class ProductAssembly
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
        
    public Guid AssemblyId { get; set; }
    public Assembly Assembly { get; set; }
    public int Quantity { get; set; }
}