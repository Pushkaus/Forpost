using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.Catalogs.TechCards;
using Forpost.Domain.Crm.InvoiceManagement;
using Forpost.Domain.ProductCreating.ManufacturingOrders;
using Forpost.Store.Postgres;

namespace Forpost.IntegrationTests.TestData;

public record ValidData
{
    private readonly ForpostContextPostgres DbContext;

    public ValidData(ForpostContextPostgres dbContext)
    {
        DbContext = dbContext;
    }

    public Contractor GetContractor()
    {
        var contractor = Contractor.Create("ValidContractor", "123456789", "Страна", "Город", ContractorType.Customer,
            null, null, null);
        DbContext.Contractors.Add(contractor);
        DbContext.SaveChanges(); 
        return contractor;
    }

    public Product GetProduct()
    {
        var product = Product.Create("ValidProduct");
        product.CategoryId = null;
        DbContext.Products.Add(product);
        DbContext.SaveChanges(); // Сохраняем изменения
        return product;
    }

    public Invoice GetInvoice()
    {
        var contractor = GetContractor(); // Теперь получаем контрактор
        var invoice = Invoice.Create("TestNumber", contractor.Id, "TestDescription", Priority.High, 
            PaymentStatus.NotPaid, DateTime.UtcNow.AddDays(2), DateTime.UtcNow);
        DbContext.Invoices.Add(invoice);
        DbContext.SaveChanges(); 
        return invoice;
    }

    public ManufacturingOrder GetManufacturingOrder()
    {
        var invoice = GetInvoice();
        var manufacturingOrder = ManufacturingOrder.Create(invoice.Id);
        DbContext.ManufacturingOrders.Add(manufacturingOrder);
        DbContext.SaveChanges(); 
        return manufacturingOrder;
    }

    public TechCard GetTechCard()
    {
        var product = GetProduct(); 
        var techCard = TechCard.Create("TestNumber", "TestDescription", product.Id);
        DbContext.TechCards.Add(techCard);
        DbContext.SaveChanges();
        return techCard;
    }

    public ManufacturingOrderComposition GetManufacturingOrderComposition()
    {
        var order = GetManufacturingOrder(); 
        var techCard = GetTechCard(); 
        var composition = ManufacturingOrderComposition.Create(order.Id, techCard.Id, 10);
        DbContext.ManufacturingOrderCompositions.Add(composition);
        DbContext.SaveChanges();
        return composition;
    }
}
