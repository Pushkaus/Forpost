using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Services
{
    public class SettingsBlocksService : ISettingsBlocksService
    {
        private readonly ISettingsBlocksRepository _settingsBlocksRepository;

        public SettingsBlocksService(ISettingsBlocksRepository settingsBlocksRepository)
        {
            _settingsBlocksRepository = settingsBlocksRepository;
        }

        public Task<List<SettingsBlock>> GetSettingsBlockBySerialNumber(int serialNumber, CancellationToken cancellationToken)
        {
            var settingsBlock = _settingsBlocksRepository.GetSettingsBlockBySerialNumber(serialNumber, cancellationToken);
            return settingsBlock;
        }
        public Task<List<SettingsBlock>> GetSettingsBlockByAccount(string account, CancellationToken cancellationToken)
        {
            var settingsBlock = _settingsBlocksRepository.GetSettingsBlockByAccount(account, cancellationToken);
            return settingsBlock;

        }
        public Task<List<SettingsBlock>> GetAllSettingsBlocks(CancellationToken cancellationToken)
        {
            var settingsBlocks = _settingsBlocksRepository.GetAllSettingsBlocks(cancellationToken);
            return settingsBlocks;
        }
        public Task UpdateIdProgonOfSettingsBlock(int serialNumber, string account, CancellationToken cancellationToken)
        {
           return _settingsBlocksRepository.UpdateIdProgonOfSettingsBlock(serialNumber, account, cancellationToken);     
        }
    }
}
