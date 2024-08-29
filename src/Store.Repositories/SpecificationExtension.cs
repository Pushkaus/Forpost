using Forpost.Domain.Primitives.EntityAnnotations;

namespace Forpost.Store.Repositories;

internal static class SpecificationExtension
{
    public static IQueryable<TEntity> ById<TEntity>(this IQueryable<TEntity> query, Guid id)
        where TEntity : class, IEntity => query.Where(entity => entity.Id == id);

    /// <summary>
    /// Только не удаленные записи (по умолчанию: На момент UtcNow)
    /// </summary>
    public static IQueryable<TEntity> NotDeletedAt<TEntity>(this IQueryable<TEntity> query, DateTimeOffset? moment = null)
        where TEntity : class, IAuditableEntity =>
        query.Where(entity => entity.DeletedAt == (moment ?? TimeProvider.System.GetUtcNow()));
}