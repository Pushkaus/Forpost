using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace Forpost.Store.Repositories
{
    public class SettingsBlocksRepository: ISettingsBlocksRepository
    {
        private readonly PostgresContext _dbContext;
        public SettingsBlocksRepository(PostgresContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<SettingsBlock>> GetSettingsBlockBySerialNumber(int serialNumber, CancellationToken cancellationToken)
        {
            var settingsBlock = await _dbContext.SettingsBlocks.FirstOrDefaultAsync(x => x.SerialNumber == serialNumber, cancellationToken);
            if (settingsBlock != null)
            {
                return new List<SettingsBlock> { settingsBlock };
            }
            return new List<SettingsBlock>();
        }
        public async Task<List<SettingsBlock>> GetSettingsBlockByAccount(string account, CancellationToken cancellationToken)
        {
            var orderBlock = await _dbContext.OrderBlocks.Where(x => x.Account == account).ToListAsync(cancellationToken);
            var blockName = orderBlock.Select(ob => ob.Block).Distinct().ToList();

            // Получаем все settingsBlock, у которых поле Block содержится в списке blockIds
            var settingsBlocks = await _dbContext.SettingsBlocks
                                                 .Where(sb => blockName.Contains(sb.Block))
                                                 .ToListAsync(cancellationToken);
            return settingsBlocks;
        }
        public async Task<List<SettingsBlock>> GetAllSettingsBlocks(CancellationToken cancellationToken)
        {
            var settingsBlocks = await _dbContext.SettingsBlocks.ToListAsync();
            return settingsBlocks;
        }
        public async Task UpdateIdProgonOfSettingsBlock(int serialNumber, string account, CancellationToken cancellationToken)
        {
            var order = await _dbContext.OrderBlocks.FirstOrDefaultAsync(x => x.Account == account && x.Deadline >= new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), cancellationToken);
            var settingsBlock = await _dbContext.SettingsBlocks.FirstOrDefaultAsync(x => x.SerialNumber == serialNumber, cancellationToken);
            
            settingsBlock.IdOrderProgon = order.Id;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

}
