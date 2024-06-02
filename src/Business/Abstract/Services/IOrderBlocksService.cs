﻿using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services
{
    public interface IOrderBlocksService : IBusinessService
    {
        public Task<List<OrderBlock>> GetOrdersByAccountNumber(string account, CancellationToken cancellationToken);

    }
}
