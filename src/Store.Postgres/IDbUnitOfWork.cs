using Microsoft.EntityFrameworkCore.Storage;

namespace Forpost.Store.Postgres;

public interface IDbUnitOfWork
{
    public IDbContextTransaction BeginTransaction();

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}