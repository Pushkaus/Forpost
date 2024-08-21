using System.Linq.Expressions;
using Forpost.Common.EntityAnnotations;
using Forpost.Common.Exceptions;

namespace Forpost.Common;

public static class ForpostErrors
{
    public static EntityNotFoundException NotFound<TEntity>(Guid id) where TEntity : IEntity => 
        new($"Сущность: {typeof(TEntity)} c id = {id} не найдена");

    public static EntityNotFoundException NotFound<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property,
        TProperty value)
        where TEntity : IEntity =>
        new(
            $"Сущность '{typeof(TEntity).Name}' по {((MemberExpression)property.Body).Member.Name} = '{value}' не найдена");

    /// <summary>
    /// Убедиться, что сущность найдена, иначе бросать <see cref="EntityNotFoundException" />
    /// </summary>
    /// <param name="entity">Сущность БД</param>
    /// <param name="property">Указание на свойство, по которому производился поиск</param>
    /// <param name="value">Значение, по которому производился поиск</param>
    /// <exception cref="EntityNotFoundException">Сущность не найдена</exception>
    public static void EnsureFoundBy<TEntity, TProperty>(this TEntity? entity,
        Expression<Func<TEntity, TProperty>> property, TProperty value) where TEntity : IEntity
    {
        if (entity is null) throw NotFound(property, value);
    }

    public static ValidationException Validation(string message) => new(message);
}