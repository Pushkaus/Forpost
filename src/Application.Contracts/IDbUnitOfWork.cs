namespace Forpost.Application.Contracts;

public interface IDbUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}