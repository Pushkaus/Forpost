using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.TechCards;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Services;

internal sealed class TechCardService: BaseBusinessService, ITechCardService
{
    public TechCardService(IDbUnitOfWork dbUnitOfWork,
        ILogger<TechCardService> logger,
        IMapper mapper,
        IConfiguration configuration,
        TimeProvider timeProvider) : base(dbUnitOfWork, logger, mapper, configuration, timeProvider)
    {
    }

    public async Task<Guid> AddAsync(TechCardCreateModel model, CancellationToken cancellationToken)
    {
        var techCard = Mapper.Map<TechCard>(model);
        var techCardId = await DbUnitOfWork.TechCardRepository.Add(techCard);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
        return techCardId;
    }

    public async Task<TechCard?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await DbUnitOfWork.TechCardRepository.GetByIdAsync(id, cancellationToken);

    public async Task<IReadOnlyList<TechCard>> GetAllAsync(CancellationToken cancellationToken) 
        => await DbUnitOfWork.TechCardRepository.GetAllAsync(cancellationToken);

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        DbUnitOfWork.TechCardRepository.DeleteById(id);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }
}