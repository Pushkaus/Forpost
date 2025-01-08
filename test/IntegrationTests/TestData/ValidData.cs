using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Products;

namespace Forpost.IntegrationTests.TestData;

public sealed class ValidData: BaseTest
{
    public ValidData(TestApplication application) : base(application)
    {
    }

    public Contractor AddContractor()
    {
        var contractor = Contractor.Create("ValidContractor", "123456789", "Страна", "Город", ContractorType.Customer,
            null,
            null, null);
        DbContext.Contractors.Add(contractor);
        return contractor;
    }

    public Product AddProduct()
    {
        var product = Product.Create("ValidProduct");
        product.CategoryId = null;
        
        DbContext.Products.Add(product);
        return product;
    }
}