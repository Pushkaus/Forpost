using System.Net;
using Forpost.Domain.Catalogs.Products;
using Forpost.Web.Client.Implementations;
using Operation = Forpost.Domain.Catalogs.Operations.Operation;
using OperationType = Forpost.Domain.Catalogs.Operations.OperationType;
using TechCard = Forpost.Domain.Catalogs.TechCards.TechCard;
using UnitOfMeasure = Forpost.Domain.Catalogs.Steps.UnitOfMeasure;

namespace Forpost.IntegrationTests.Catalogs;

public sealed class TechCardEndpoints: BaseTest
{
    public TechCardEndpoints(TestApplication application) : base(application)
    {
    }

    [Fact(DisplayName = "Добавление тех.карты, успешное добавление")]
    public async Task AddTechCard_ValidInput_Return201()
    {
        // Arrange
        var product = new Product
        {
            Name = "product",
            Version = "v1",
        };
        var techCard = new TechCardCreateRequest
        {
            Number = "1321312312",
            Description = "fdsfdsfdfsddsfdsfdsfssfd",
            ProductId = product.Id,
        };
        // Act
        var result = Client.CompositionTechCardClient.CreateTechCardAsync(techCard);
        // Assert
        result.Should().NotBeNull();
    }

    [Fact(DisplayName = "Добавления компонента тех.карты, успешное добавление")]
    public async Task AddTechCardItem_ValidInput_Return201()
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
            Number = "112312313",
            Description = "das",
            ProductId = product.Id
        };
        DbContext.TechCards.Add(techCard);
        var techCardItem = new TechCardItemRequest
        {
            TechCardId = techCard.Id,
            ProductId = product.Id,
            Quantity = 10
        };
        // Act
        var result = Client.TechCardItemClient.CreateTechCardItemAsync(techCardItem);
        // Assert
        result.Should().NotBeNull();
    }

    [Fact(DisplayName = "Добавления этапа в тех.карту, успешное добавление")]
    public async Task AddTechCardStep_ValidInput_Return201()
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
            Number = "112312313",
            Description = "das",
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
        var step = new Step
        {
            TechCardId = techCard.Id,
            OperationId = operation.Id,
            Description = "dsaa",
            Duration = TimeSpan.FromDays(2),
            Cost = 10,
            UnitOfMeasure = (Web.Client.Implementations.UnitOfMeasure)100
        };
        var techCardStep = new TechCardStepRequest
        {
            TechCardId = techCard.Id,
            StepId = step.Id,
            Number = 1
        };
        // Act
        var result = Client.TechCardStepClient.CreateTechCardStepAsync(techCardStep);
        // Assert
        result.Should().NotBeNull();
    }
}