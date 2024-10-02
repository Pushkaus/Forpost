using Forpost.Domain.Catalogs.Contractors;
using Forpost.Web.Client.Implementations;

namespace Forpost.IntegrationTests.Catalogs;

public sealed class ContractorEndpoints: BaseTest
{
    public ContractorEndpoints(TestApplication application) : base(application)
    {
    }

    [Fact(DisplayName = "Добавление контрагента, успешное добавление")]
    public async Task AddContractor_ValidInput_Return201()
    {
        // Arrange
        var contractor = new ContractorRequest();
        contractor.Name = "test";
        // Act
        var result = Client.ContractorClient.CreateContractorAsync(contractor);
        // Assert
        result.Should().NotBeNull();
    }
}