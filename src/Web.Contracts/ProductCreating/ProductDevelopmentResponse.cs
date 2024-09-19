using Forpost.Domain.ProductCreating.ProductDevelopment;

namespace Forpost.Web.Contracts.ProductCreating;

internal sealed class ProductDevelopmentResponse
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public Guid ManufacturingProcessId { get; set; }
    public string BatchNumber { get; set; } = null!;
    /// <summary>
    /// ID задачи, где находится продукт
    /// </summary>
    public Guid IssueId { get; set; }
    public string OperationName { get; set; } = null!;
    /// <summary>
    /// Серийный номер продукта
    /// </summary>
    public string SerialNumber { get; set; } = null!;
    /// <summary>
    /// Вариант настройки
    /// </summary>
    public SettingOption? SettingOption { get; set; }
    
    public ProductStatus Status { get; set; }
}