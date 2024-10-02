using Bogus;
using Forpost.Domain.Catalogs.Category;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Store.Postgres;

namespace Forpost.IntegrationTests;

/// <summary>
/// Строитель тестовых данных
/// </summary>
/// <remarks>В<see cref="TestData"/> при сохранении попадают только последние добавленные сущностии</remarks>
public class TestDataBuilder(ForpostContextPostgres dbContext)
{
    private readonly Faker _faker = new(locale: "ru");
    private Contractor? _contractor;
    private Category? _parentCategory;
    private Category? _childCategory;

    public TestDataBuilder AddContractor(int count = 1)
    {
        for (var i = 0; i < count; i++)
        {
            _contractor = Contractor.New(_faker.Name.FullName());
            dbContext.Contractors.Add(_contractor);
        }
        
        return this;
    }

    public TestDataBuilder AddRootCategory()
    {
        _parentCategory = new Category { Name = _faker.Commerce.Categories(1).First(), ParentId = null };
        
        dbContext.Categories.Add(_parentCategory);
        return this;
    }
    
    public TestDataBuilder AddChildCategory()
    {
        var parentId = _parentCategory?.Id ?? throw new InvalidOperationException();
        _childCategory = new Category { Name = _faker.Commerce.Categories(1).First(), ParentId = parentId };
        
        dbContext.Categories.Add(_childCategory);
        return this;
    }

    public async Task<TestData> SaveToDatabaseAsync()
    {
        await dbContext.SaveChangesAsync();

        return new TestData
        {
            Contractor = _contractor,
            ParentCategory = _parentCategory,
            ChildCategory = _childCategory,
        };
    }

}