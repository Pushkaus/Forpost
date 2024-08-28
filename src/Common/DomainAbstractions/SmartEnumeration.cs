using System.Reflection;

namespace Forpost.Common.DomainAbstractions;

/// <summary>
/// Реализация Smart-enum
/// </summary>
// TODO: переход состояний
public abstract class SmartEnumeration<TEnum> : IEquatable<SmartEnumeration<TEnum>>
    where TEnum : SmartEnumeration<TEnum>
{
    private static readonly Dictionary<int, TEnum> Enumerations = CreateEnumerations();

    private static Dictionary<int, TEnum> CreateEnumerations()
    {
        var type = typeof(TEnum);
        return type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fieldInfo => type.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo => (TEnum)fieldInfo.GetValue(default)!)
            .ToDictionary(source => source.Value);
    }
    
    protected SmartEnumeration(string name, int value) => (Name, Value) = (name, value);

    /// <summary>
    /// Значение
    /// </summary>
    public int Value { get; protected init; }
    
    /// <summary>
    /// Название поля
    /// </summary>
    public string Name { get; protected init; }

    /// <summary>
    /// Получить экземпляр перечисления по имени
    /// </summary>
    public static TEnum FromName(string name) => Enumerations.Values.Single(enumeration => enumeration.Name == name);

    /// <summary>
    /// Получить экземпляр перечисления по числовому значению
    /// </summary>
    public static TEnum FromValue(int value) => Enumerations.GetValueOrDefault(value) ?? throw new KeyNotFoundException();

    public bool Equals(SmartEnumeration<TEnum>? other)
    {
        if(other is null) return false;
        return GetType() == other.GetType() && Value == other.Value;
    }

    public override bool Equals(object? obj) => obj is SmartEnumeration<TEnum> other && Equals(other);

    public override int GetHashCode() => Value.GetHashCode();
}