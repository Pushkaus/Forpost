using Forpost.IntegrationTests.TestData;
using Forpost.Web.Client.Implementations;


namespace Forpost.IntegrationTests.InvoiceManagment;

public sealed class InvoiceEndpointTests : BaseTest
{

    public InvoiceEndpointTests(TestApplication application) : base(application)
    {
    }

    [Fact(DisplayName = "Добавление счета, успешное добавление")]
    public async Task AddInvoice_ValidInput_ReturnGuid()
    {
        // Arrange
        var product = ValidData.GetProduct(); 
        var validProduct = new InvoiceProductCreate
        {
            ProductId = product.Id,
            Quantity = 10
        };

        var products = new List<InvoiceProductCreate> { validProduct };

        var contractor = ValidData.GetContractor(); 
        
        var invoice = new InvoiceCreateRequest
        {
            Number = "Number10",
            ContractorId = contractor.Id,
            Description = "Description",
            Priority = 100,
            PaymentStatus = 100,
            PaymentDeadline = DateTime.UtcNow.AddDays(7), 
            CreateDate = DateTime.UtcNow, 
            PaymentPercentage = 100,
            Products = products
        };

        // Act
        var invoiceId = await Client.InvoiceClient.Invoice_CreateAsync(invoice);
        
        // Assert
        invoiceId.Should().NotBe(Guid.Empty);
        invoiceId.Should<Guid>(); 
    }
}