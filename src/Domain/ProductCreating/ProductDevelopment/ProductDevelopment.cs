using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.ProductCreating.ProductDevelopment;

public sealed class ProductDevelopment : DomainEntity
{
    public void GenerateInitialSerialNumber(string batchNumber, int sequenceNumber)
    {
        SerialNumber = $"{batchNumber}-{sequenceNumber:D2}";
        Status = ProductStatus.InProgress;
    }

    public void SetSerialNumber(string serialNumber)
    {
        SerialNumber = serialNumber;
    }

    public void SetSettingOption(SettingOption settingOption)
    {
        SettingOption = settingOption;
    }
    public Guid ProductId { get; set; }
    public Guid ManufacturingProcessId { get; set; }
    /// <summary>
    /// ID задачи, где находится продукт
    /// </summary>
    public Guid IssueId { get; set; }
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