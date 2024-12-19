using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Catalogs.TechCards.Operations;

public sealed class OperationType: SmartEnumeration<OperationType>
{
    /// <summary>
    /// Базовая операция, где необходимо учесть количество продукта
    /// </summary>
    public static readonly OperationType Basic = new(nameof(Basic), 0);
    /// <summary>
    /// Подготовительная операция. Готовится сразу партия
    /// </summary>
    public static readonly OperationType Preparatory = new(nameof(Preparatory), 100);
    
    public OperationType(string name, int value) : base(name, value)
    {
    }
}