using Forpost.Web.Client.Implementations;

namespace Forpost.IntegrationTests.Catalogs;

public sealed class ProductEndpoints: BaseTest
{
    public ProductEndpoints(TestApplication application) : base(application)
    {
    }

    [Fact(DisplayName = "Добавление продукта, успешное добавление")]
    public async Task AddProduct_ValidInput_Return201()
    {
        // Arrange
        var product = new ProductCreateRequest
        {
            Name = "Product",
            Version = "v1"
        };
        // Act
        var result = Client.ProductClient.Create8Async(product);
        // Assert
        result.Should().NotBeNull();
    }
}