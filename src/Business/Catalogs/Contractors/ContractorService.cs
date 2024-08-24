using AutoMapper;
using Forpost.Common;
using Forpost.EventBus;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Catalogs.Contractors;

internal sealed class ContractorService : BusinessService, IContractorService
{
    public ContractorService(
        IDbUnitOfWork dbUnitOfWork,
        ILogger<BusinessService> logger,
        IMapper mapper,
        IConfiguration configuration,
        IDomainEventBus domainEventBus,
        TimeProvider timeProvider
    )
        : base(dbUnitOfWork, logger, mapper, configuration, domainEventBus, timeProvider)
    {
    }

    public async Task<Guid> AddAsync(string name, CancellationToken cancellationToken)
    {
        var contragent = new ContractorEntity { Name = name };
        var contragentId =  DbUnitOfWork.ContragentRepository.Add(contragent);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
        return contragentId;
    }

    public async Task<IReadOnlyList<ContractorEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        var contragents = await DbUnitOfWork.ContragentRepository.GetAllAsync(cancellationToken);

        return contragents;
    }

    public async Task<ContractorEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var contragent = await DbUnitOfWork.ContragentRepository.GetByIdAsync(id, cancellationToken);
        if (contragent == null) throw ForpostErrors.NotFound<ContractorEntity>(id);

        return contragent;
    }
}