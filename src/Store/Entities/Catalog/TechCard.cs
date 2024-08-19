using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

/// <summary>
///     Технологическая карта
/// </summary>
public sealed class TechCard : IEntity
{
    /// <summary>
    ///     Номер тех.карты
    /// </summary>
    public string Number { get; set; } = null!;

    /// <summary>
    ///     Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Ссылка на продукт, относительно которого составляется тех.карта
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    ///     Создатель тех.карты
    /// </summary>
    public Guid CreatedById { get; set; }

    public Guid Id { get; set; }
}