namespace Forpost.Common.Extensions;

public static class EnumerableExtensions
{
    /// <summary>
    /// Является ли коллекция пустой
    /// </summary>
    public static bool IsEmpty<TElement>(this IEnumerable<TElement> source) => !source.Any();

    /// <summary>
    /// Имеет ли коллекция хотя бы один элемент
    /// </summary>
    public static bool IsNotEmpty<TElement>(this IEnumerable<TElement> source) => source.Any();

    /// <summary>
    /// Представить один элемент, как коллекцию
    /// </summary>
    public static IEnumerable<TElement> Yield<TElement>(this TElement source) => [source];
}