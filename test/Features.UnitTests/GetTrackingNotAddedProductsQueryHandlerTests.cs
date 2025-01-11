using AutoFixture;
using Forpost.Common.Exceptions;
using Forpost.Domain.ProductCreating.ManufacturingOrders;
using Forpost.Features.Crm.InvoiceManagement.Invoices;
using Forpost.Features.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;
using Moq;

namespace Forpost.Features.UnitTests;

public class GetTrackingNotAddedProductsQueryHandlerTests : UnitTestBase
{
    private readonly GetTrackingNotAddedProductsQueryHandler _sut;

    public GetTrackingNotAddedProductsQueryHandlerTests()
    {
        _sut = AutoFixture.Create<GetTrackingNotAddedProductsQueryHandler>();
    }

    [Fact(DisplayName = "Заказ не найден. Должно выброситься искелючение")]
    public async Task OrderNotFound_Should_Throw_EntityNotFoundException()
    {
        // Arrange
        var id = Guid.NewGuid();
        var query = new GetTrackingNotAddedProductsQuery(id);
        ManufacturingOrderDomainRepositoryMock.Setup(x => x.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(null as ManufacturingOrder);
        
        // Act
        var act = async () => await _sut.Handle(query, CancellationTokenNone);
        // Assert
        await act.Should().ThrowAsync<EntityNotFoundException>();
    }
    
}