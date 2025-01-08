
using Forpost.IntegrationTests.TestData;
using Forpost.Web.Client.Implementations;

namespace Forpost.IntegrationTests.InvoiceManagment;

public sealed class InvoiceEndpointTests : BaseTest
{
    private readonly ValidData _validData;
    
    public InvoiceEndpointTests(TestApplication application, ValidData validData) : base(application)
    {
        _validData = validData;
    }

    [Fact(DisplayName = "Добавление счета, успешное добавление")]
    public async Task AddInvoice_ValidInput_Return201()
    {
        // Arrange
        var product = _validData.AddProduct();
        
        var validProduct = new InvoiceProductCreate
        {
            ProductId = product.Id,
            Quantity = 10
        };

        var products = new List<InvoiceProductCreate> { validProduct };

        var contractor = _validData.AddContractor();

        await DbContext.SaveChangesAsync();

        var invoice = new InvoiceCreateRequest
        {
            Number = "Number10",
            ContractorId = contractor.Id,
            Description = "Description",
            Priority = 100,
            PaymentStatus = 100,
            PaymentDeadline = TimeProvider.System.GetUtcNow().AddDays(7),
            CreateDate = TimeProvider.System.GetUtcNow(),
            PaymentPercentage = 100,
            Products = products
        };

        // Act
        var response = await Client.InvoiceClient.Invoice_CreateAsync(invoice);
        
        // Assert
        response.Should<Guid>();
    }

    
}