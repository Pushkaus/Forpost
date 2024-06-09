using Forpost.Store.Entities;


namespace Forpost.Store.Repositories.Abstract.Repositories
{
    public interface ISettingsBlocksRepository
    {
        public Task<List<SettingsBlock>> GetSettingsBlockBySerialNumber(int serialNumber, CancellationToken cancellationToken);
        public Task<List<SettingsBlock>> GetSettingsBlockByAccount(string account, CancellationToken cancellationToken);
        public Task<List<SettingsBlock>> GetAllSettingsBlocks(CancellationToken cancellationToken);
        public Task UpdateIdProgonOfSettingsBlock(int serialNumber, string account, CancellationToken cancellationToken);
    }
}
