namespace Forpost.Application.Contracts.ProductCreating.ProductsDevelopments;

public sealed class ProductDevelopmentModel
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public Guid ManufacturingProcessId { get; set; }
    public Guid IssueId { get; set; }
    public string OperationName { get; set; } = string.Empty;
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