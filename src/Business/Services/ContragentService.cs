using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Abstract.Services;
using Forpost.Common;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Services;

internal sealed class ContragentService : BaseBusinessService, IContragentService
{
    public ContragentService(IDbUnitOfWork dbUnitOfWork, 
        ILogger<ContragentService> logger,
        IMapper mapper,
        IConfiguration configuration, 
        TimeProvider timeProvider) : base(dbUnitOfWork, logger, mapper, configuration, timeProvider)
    {
    }

    public async Task AddAsync(string name, CancellationToken cancellationToken)
    {
        var contragent = new Contractor { Name = name };
        DbUnitOfWork.ContragentRepository.Add(contragent);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Contractor>> GetAllAsync(CancellationToken cancellationToken)
    {
        var contragents = await DbUnitOfWork.ContragentRepository.GetAllAsync(cancellationToken);

        return contragents;
    }

    public async Task<Contractor?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var contragent = await DbUnitOfWork.ContragentRepository.GetByIdAsync(id, cancellationToken);
        if (contragent == null) throw ForpostErrors.NotFound<Contractor>(id);

        return contragent;
    }
}