namespace Forpost.Application.Contracts;

public sealed class EntityPagedResult<TEntity> 
{
    public IReadOnlyCollection<TEntity> Items { get; set; } = new List<TEntity>();
    public int TotalCount { get; set; }
}