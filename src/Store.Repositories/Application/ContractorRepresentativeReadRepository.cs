using Forpost.Application.Contracts.Catalogs.Contractors.ContractorRepresentatives;
using Forpost.Domain.Catalogs.Contractors.ContractorRepresentatives;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class ContractorRepresentativeReadRepository : IContractorRepresentativeReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public ContractorRepresentativeReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<ContractorRepresentative>> GetByContractorIdAsync(Guid contractorId,
        CancellationToken cancellationToken)
    {
        return await _dbContext.ContractorRepresentatives.Where(c => c.ContractorId == contractorId)
            .ToListAsync(cancellationToken);
    }
}