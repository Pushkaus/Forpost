using System.Net;
using Forpost.Common.Utils;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Products;
using Forpost.Web.Client.Implementations;

namespace Forpost.IntegrationTests.InvoiceManagment;

public sealed class InvoiceEndpointTests: BaseTest
{
    public InvoiceEndpointTests(TestApplication application) : base(application)
    {
    }
    [Fact(DisplayName = "Добавление счета, успешное добавление")]
    public async Task AddInvoice_ValidInput_Return201()
    {
        var contractor = Contractor.New("contractor");
        DbContext.Contractors.Add(contractor);
        var product = Product.Create("product");
        DbContext.Products.Add(product);
        await DbContext.SaveChangesAsync();
        var invoiceProducts = new List<InvoiceProduct>
        {
            new InvoiceProduct
            {
                ProductId = product.Id,
                Quantity = 10
            }
        };
        var invoice = new InvoiceCreateRequest
        {
            Number = "1",
            ContragentId = contractor.Id,
            Description = null,
            DaysShipment = 10,
            PaymentPercentage = 10,
            Products = invoiceProducts 
        };
        var result = await Client.InvoiceClient.ExposeAsync(invoice);
        
       result.Should().NotBeEmpty();
    }
    
}