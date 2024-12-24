namespace Forpost.Application.Contracts.Catalogs.TechCards.TechCardOperations;

public sealed class TechCardOperationModel
{
    public Guid Id { get; set; }
    public string TechCardNumber { get; set; } = string.Empty;
    public Guid TechCardId { get; set; }
    public string OperationName { get; set; }
    public Guid OperationId { get; set; }
    /// <summary>
    /// Номер в очереди
    /// </summary>
    public int Number { get; set; }
}