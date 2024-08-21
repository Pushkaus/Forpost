using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.TechCards;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

internal sealed class TechCardService: ITechCardService
{
    private readonly ITechCardRepository _techCardRepository;
    private readonly IMapper _mapper;

    public TechCardService(IMapper mapper, ITechCardRepository techCardRepository)
    {
        _mapper = mapper;
        _techCardRepository = techCardRepository;
    }

    public async Task<Guid> AddAsync(TechCardCreateModel model, CancellationToken cancellationToken)
    {
        var techCard = _mapper.Map<TechCard>(model);
        return await _techCardRepository.AddAsync(techCard, cancellationToken);
    }

    public async Task<TechCard?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await _techCardRepository.GetByIdAsync(id, cancellationToken);

    public async Task<IReadOnlyList<TechCard>> GetAllAsync(CancellationToken cancellationToken) 
        => await _techCardRepository.GetAllAsync(cancellationToken);

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await _techCardRepository.DeleteByIdAsync(id, cancellationToken);
}