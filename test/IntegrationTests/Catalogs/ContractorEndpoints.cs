using Forpost.Web.Client.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Forpost.IntegrationTests.Catalogs;

public sealed class ContractorEndpoints(TestApplication application) : BaseTest(application)
{
    [Fact(DisplayName = "Добавление контрагента. Успешное добавление. Статус 201")]
    public async Task CreateContractor_ValidInput_Return201()
    {
        // Arrange
        var request = new ContractorRequest { Name = Faker.Name.FullName() };
        // Act
        var id = await Client.ContractorClient.CreateContractorAsync(request);
        // Assert
        var createdContractor = await DbContext.Contractors.FirstOrDefaultAsync(x => x.Id == id);
        createdContractor.Should().BeEquivalentTo(request);
    }

    [Fact(DisplayName = "Получение контрагента по ИД. Контрагент существует. Успешное получение. Статус 200")]
    public async Task GetContractorById_ContractorExist_Return200()
    {
        // Arrange
        var testData = await TestDataBuilder.AddContractor().SaveToDatabaseAsync();
        // Act
        var contractor = await Client.ContractorClient.GetContractorByIdAsync(testData.Contractor!.Id);
        // Assert
        contractor.Should().BeEquivalentTo(testData.Contractor, options => options.ExcludingMissingMembers());
    }
    
    [Fact(DisplayName = "Получение контрагента по ИД. Контрагента не существует. Статус 404")]
    public async Task GetContractorById_ContractorNotExist_Return404()
    {
        // Act
        var act = () => Client.ContractorClient.GetContractorByIdAsync(It.IsAny<Guid>());
        // Assert
        await act.ShouldThrowApiExceptionWithStatusCodeAsync(StatusCodes.Status404NotFound);
    }
    
    //TODO: сделай модель пагинации правильную, её возвращай в контроллере 
    
    //TODO: сделать ВЕЗДЕ модель пагинации, так как иначе сваггер и генератторы не поймут как десериализовывать ответ
    // лучше больше инфармации о пейджинке засунуть, чтобы UI было легче склоняюсь
    
    //TODO: допиши тесты на случаи 
    //недопустимые Limit, Offset, filetExpression
    //постраниченое получение без фильтрации
    //постраничное получение с фильтрацией
    //записей вообще нет
    //и т.д.
    
    
    
    // [Fact(DisplayName = "Получение всех контрогентов без фильтрации. Успешное получение. Статус 200")]
    // public async Task GetAllContractors_ContractorsExist_Return200()
    // {
    //     // Arrange
    //     await TestDataBuilder.AddContractor(count: 3).SaveToDatabaseAsync();
    //     // Act
    //     var response = await Client.ContractorClient.GetAllContractorsAsync(0, 4, null, null);
    //     // Assert
    //     var contractors = await DbContext.Contractors.ToArrayAsync();
    //     response.Should().BeEquivalentTo(contractors);
    // }
}