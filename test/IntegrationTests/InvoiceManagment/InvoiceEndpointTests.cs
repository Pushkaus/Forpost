namespace Forpost.IntegrationTests.InvoiceManagment;

public sealed class InvoiceEndpointTests: BaseTest
{
    public InvoiceEndpointTests(TestApplication application) : base(application)
    {
    }
    [Fact(DisplayName = "Добавление счета, успешное добавление")]
    public async Task AddInvoice_ValidInput_Return201()
    {
        return;
    }
    
}