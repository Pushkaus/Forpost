using Forpost.IntegrationTests.TestData;
using Forpost.Web.Client.Implementations;

namespace Forpost.IntegrationTests.ProductCreating;

public sealed class ManufacturingOrderEndpointTests: BaseTest
{
    public ManufacturingOrderEndpointTests(TestApplication application) : base(application)
    {
    }

    [Fact]
    public async Task AddManufacturingOrder_ValidData_Return201()
    {
        // Arrange
        var invoice = ValidData.GetInvoice();
        DbContext.Add(invoice);
        await DbContext.SaveChangesAsync();
        var request = new CreateManufacturingOrderRequest
        {
            InvoiceId = invoice.Id
        };
        // Act
        var orderId = await Client.ManufacturingOrderClient.ManufacturingOrder_CreateAsync(request); 
        // Assert
        orderId.Should().NotBe(Guid.Empty);
        orderId.Should<Guid>();
    }
}