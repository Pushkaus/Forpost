using Forpost.Domain.ProductCreating.ProductDevelopment;

namespace Forpost.Application.Contracts.ProductsDevelopments;

internal sealed class ProductDevelopmentDetails
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public Guid ManufacturingProcessId { get; set; }
    public Guid IssueId { get; set; }
    public string BatchNumber { get; set; } = string.Empty;
    /// <summary>
    /// Серийный номер продукта
    /// </summary>
    public string SerialNumber { get; set; } = null!;
    /// <summary>
    /// Вариант настройки
    /// </summary>
    public SettingOptionRead? SettingOption { get; set; }
    public ProductStatusRead StatusRead { get; set; }
}