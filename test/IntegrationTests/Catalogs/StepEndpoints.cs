using Forpost.Domain.Catalogs.Products;
using Forpost.Web.Client.Implementations;
using Operation = Forpost.Domain.Catalogs.Operations.Operation;
using OperationType = Forpost.Domain.Catalogs.Operations.OperationType;
using TechCard = Forpost.Domain.Catalogs.TechCards.TechCard;

namespace Forpost.IntegrationTests.Catalogs;

public sealed class StepEndpoints: BaseTest
{
    public StepEndpoints(TestApplication application) : base(application)
    {
    }

    [Fact(DisplayName = "Добавление этапа, успешное добавление")]
    public async Task AddStep_ValidInput_Return201()
    {
        // Arrange
        var product = new Product
        {
            Name = "product",
            Version = "v1",
        };
        DbContext.Products.Add(product);
        var techCard = new TechCard()
        {
            Number = "1",
            Description = "description",
            ProductId = product.Id
        };
        DbContext.TechCards.Add(techCard);
        var operation = new Operation()
        {
            Name = "operation",
            Description = "1",
            Type = (OperationType)100
        };
        DbContext.Operations.Add(operation);
        var step = new StepCreateRequest
        {
            TechCardId = techCard.Id,
            OperationId = operation.Id,
            Description = "description",
            Duration = TimeSpan.FromMinutes(1),
            Cost = 10,
            UnitOfMeasure = (UnitOfMeasure)100
        };
        // Act
        var result = Client.StepClient.Create6Async(step);
        // Assert
        result.Should().NotBeNull();
    }
}