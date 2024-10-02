using Forpost.Domain.Catalogs.Category;
using Forpost.Domain.Catalogs.Contractors;

namespace Forpost.IntegrationTests;

/// <summary>
/// Тестовые данные
/// </summary>
public sealed class TestData
{
    #region Catalogs

    public Contractor? Contractor { get; set; }
    public Category? ParentCategory { get; set; }
    public Category? ChildCategory { get; set; }

    #endregion

}