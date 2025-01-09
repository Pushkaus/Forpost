using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.Catalogs.TechCards;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Domain.ProductCreating.ManufacturingOrders;

namespace Forpost.IntegrationTests.TestData;

public record ValidData
{
    public static Contractor GetContractor()
    {
        var contractor = Contractor.Create("ValidContractor", "123456789", "Страна", "Город", ContractorType.Customer,
            null,
            null, null);
        return contractor;
    }

    public static Product GetProduct()
    {
        var product = Product.Create("ValidProduct");
        product.CategoryId = null;
        
        return product;
    }

    public static Invoice GetInvoice()
    {
        var contractor = GetContractor();
        var invoice = Invoice.Create("TestNumber", contractor.Id, "TestDescription", Priority.High, 
            PaymentStatus.NotPaid, TimeProvider.System.GetUtcNow().AddDays(2), TimeProvider.System.GetUtcNow().Date);
        return invoice;
    }

    public static ManufacturingOrder GetManufacturingOrder()
    {
        var invoice = GetInvoice();
        var manufacturingOrder = ManufacturingOrder.Create(invoice.Id);
        return manufacturingOrder;
    }

    public static TechCard GetTechCard()
    {
        var product = GetProduct();
        var techCard = TechCard.Create("TestNumber", "TestDescription", product.Id);
        return techCard;
    }
    
    public static ManufacturingOrderComposition GetManufacturingOrderComposition()
    {
        var order = GetManufacturingOrder();
        var techCard = GetTechCard();
        var composition = ManufacturingOrderComposition.Create(order.Id, techCard.Id, 10);
        return composition;
    }
}