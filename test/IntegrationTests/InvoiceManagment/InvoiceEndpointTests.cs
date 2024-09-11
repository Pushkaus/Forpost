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
        var a = IdentityProvider.GetUserId();
        var b = IdentityProvider.GetRoleId();
        ///TODO;
        // Arrange
        var invoiceProduct = new List<InvoiceProduct>();
        var productEntity = new Product
        {
            Name = "BPS",
            Version = "v1",
        };
        var product = DbContext.Products.Add(productEntity);
        invoiceProduct.Add(new()
        {
            ProductId = product.Entity.Id,
            Quantity = 10
        });
        var contragent = DbContext.Contractors.Add(Contractor.New("SGEP"));
        var invoice = new InvoiceCreateRequest()
        {
            Number = "1",
            ContragentId = contragent.Entity.Id,
            Description = "Тестовый счет",
            DaysShipment = 10,
            PaymentPercentage = 20,
            Products = invoiceProduct
        };
        // // Act
        // ..var invoiceId = await Client.InvoiceClient.ExposeAsync(invoice);
        // // Assert
        // invoiceId.Should().NotBeEmpty();
        // invoiceId.Should().NotBe(Guid.Empty);
        var contragentId = Client.ContractorClient.Create9Async("Толик");
        contragentId.Should().NotBeNull();
    }
    
}