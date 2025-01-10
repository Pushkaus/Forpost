using System.ComponentModel;
using System.Net;
using Forpost.IntegrationTests.TestData;
using Forpost.Web.Client.Implementations;

namespace Forpost.IntegrationTests.ProductCreating;

public sealed class ManufacturingOrderEndpointTests: BaseTest
{
    public ManufacturingOrderEndpointTests(TestApplication application) : base(application)
    {
    }
    //TODO;
    [Fact(DisplayName = "Добавление производственного заказа, успешное добавление")]
    public async Task AddManufacturingOrder_ValidData_Return201()
    {
        // Arrange
        var invoice = ValidData.GetInvoice();
        var request = new CreateManufacturingOrderRequest
        {
            InvoiceId = invoice.Id
        };

        // Act
        var response = await Client.ManufacturingOrderClient.ManufacturingOrder_CreateAsync(request);

        // Assert
        response.Should<Guid>();
    }

}