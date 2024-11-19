using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.StorageManagement;

public interface IStorageReadRepository: IApplicationReadRepository
{
    public Task<IReadOnlyCollection<StorageModel>> GetAllStorage(CancellationToken cancellationToken);
}