using System.Linq.Expressions;
using Forpost.Common.EntityAnnotations;
using Forpost.Common.Exceptions;

namespace Forpost.Common;

public static class ForpostErrors
{
    public static EntityNotFoundException NotFound<TEntity>(Guid id) where TEntity : IEntity
        => new EntityNotFoundException($"Сущность: {typeof(TEntity)} c id = {id} не найдена");
    
    public static EntityNotFoundException NotFound<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property,
        TProperty value)
        where TEntity: IEntity => 
        new($"Сущность '{typeof(TEntity).Name}' по {((MemberExpression)property.Body).Member.Name} = '{value}' не найдена");


}