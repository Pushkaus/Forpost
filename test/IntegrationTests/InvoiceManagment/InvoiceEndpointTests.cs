using System.Net;
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
        ///TODO;
        // Arrange
        var invoiceProduct = new List<InvoiceProduct>();
        invoiceProduct.Add(new()
        {
            ProductId = Guid.Parse("b88a2b64-2938-4ab6-aa6e-329ddac9c53c"),
            Quantity = 10
        });
        var invoice = new InvoiceCreateRequest()
        {
            Number = "1",
            ContragentId = Guid.Parse("281a2392-74a6-4cd9-b5fb-0dc11c38ddfb"),
            Description = "Тестовый счет",
            DaysShipment = 10,
            PaymentPercentage = 20,
            Products = invoiceProduct
        };
        // Act
        var invoiceId = await Client.InvoiceClient.ExposeAsync(invoice);
        // Assert
        invoiceId.Should().NotBeEmpty();
        invoiceId.Should().NotBe(Guid.Empty);

    }
    
}