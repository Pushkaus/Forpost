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
        var totalCount = await _dbContext.Contractors.NotDeletedAt().CountAsync(cancellationToken);
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
                ContractorType = contractor.ContractorType
            });
        if (!string.IsNullOrWhiteSpace(filter.Name))
        {
            query = query.Where(contractor => contractor.Name.Contains(filter.Name));
        }

        if (filter.ContractorTypeValue.HasValue)
        {
            var contractorType = ContractorType.FromValue(filter.ContractorTypeValue.Value);
            query = query.Where(contractor => contractor.ContractorType == contractorType);
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

    public async Task<ContractorModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
       return await _dbContext.Contractors.AsQueryable().NotDeletedAt()
            .Where(entity => entity.Id == id)
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
                ContractorType = contractor.ContractorType
            }).FirstOrDefaultAsync(cancellationToken);
    }
}