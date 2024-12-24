using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.TechCards.TechCardOperations;

/// <summary>
/// Сущность, связывающая операции и тех.карту
/// </summary>
public sealed class TechCardOperation : DomainEntity
{
    public Guid TechCardId { get; private set; }
    public Guid OperationId { get; private set; }
    /// <summary>
    /// Номер в очереди
    /// </summary>
    public int Number { get; private set; }

    public static TechCardOperation Add(Guid techCardId, Guid stepId, int number) 
        => new(techCardId, stepId, number);

    private TechCardOperation(Guid techCardId, Guid operationId, int number)
    {
        TechCardId = techCardId;
        OperationId = operationId;
        Number = number;
    }

}