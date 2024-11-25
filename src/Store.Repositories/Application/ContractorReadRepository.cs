using System.Linq.Dynamic.Core;
using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Contractors;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class ContractorReadRepository: IContractorReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public ContractorReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EntityPagedResult<ContractorModel>> GetAllAsync(ContractorFilter filter, CancellationToken cancellationToken)
    {
        var totalCount = await _dbContext.Contractors.CountAsync(cancellationToken);
        var query = _dbContext.Contractors.AsQueryable().NotDeletedAt()
            .Select(contractor => new ContractorModel
            {
                Id = contractor.Id,
                Name = contractor.Name,
                INN = contractor.INN,
                Country = contractor.Country,
                City = contractor.City,
                Description = contractor.Description,
                DiscountLevel = contractor.DiscountLevel,
                LogisticInfo = contractor.LogisticInfo,
                ContractType = contractor.ContractType
            });
        if (!string.IsNullOrWhiteSpace(filter.Name))
        {
            query = query.Where(contractor => contractor.Name.Contains(filter.Name));
        }

        if (filter.ContractTypeValue.HasValue)
        {
            var contractorType = ContractorType.FromValue(filter.ContractTypeValue.Value);
            query = query.Where(contractor => contractor.ContractType == contractorType);
        }

        var result = await query
            .OrderByDescending(x => x.Id)
            .Skip(filter.Skip)
            .Take(filter.Limit)
            .ToListAsync(cancellationToken);
        return new EntityPagedResult<ContractorModel>
        {
            Items = result,
            TotalCount = totalCount
        };
    }
}