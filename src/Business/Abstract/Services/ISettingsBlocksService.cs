using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forpost.Business.Abstract.Services
{
    public interface ISettingsBlocksService: IBusinessService
    {
        public Task<List<SettingsBlock>> GetSettingsBlockBySerialNumber(int serialNumber, CancellationToken cancellationToken);
        public Task<List<SettingsBlock>> GetSettingsBlockByAccount(string account, CancellationToken cancellationToken);
        public Task<List<SettingsBlock>> GetAllSettingsBlocks(CancellationToken cancellationToken);
        public Task UpdateIdProgonOfSettingsBlock(int serialNumber, string account, CancellationToken cancellationToken);
    }
}
