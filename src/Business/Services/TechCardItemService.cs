using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.TechCardItems;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

internal sealed class TechCardItemService: ITechCardItemService
{
    private readonly ITechCardItemRepository _techCardItemRepository;

    private readonly IMapper _mapper;

    public TechCardItemService(ITechCardItemRepository techCardItemRepository, IMapper mapper)
    {
        _techCardItemRepository = techCardItemRepository;
        _mapper = mapper;
    }

    public async Task<Guid> AddAsync(TechCardItem model, CancellationToken cancellationToken)
    {
        return await _techCardItemRepository.AddAsync(model, cancellationToken);
    }

    public async Task<TechCardItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await _techCardItemRepository.GetByIdAsync(id, cancellationToken);

    public async Task<IReadOnlyList<TechCardItem>> GetAllAsync(CancellationToken cancellationToken) 
        => await _techCardItemRepository.GetAllAsync(cancellationToken);

    public async Task<IReadOnlyCollection<ItemsInTechCardModel>> GetAllItemsByTechCardId(Guid techCardId, CancellationToken cancellationToken)
    {
        var items = await _techCardItemRepository.GetAllItemsByTechCardId(techCardId, cancellationToken);
        var result = _mapper.Map<IReadOnlyCollection<ItemsInTechCardModel>>(items);
        return result;
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await _techCardItemRepository.DeleteByIdAsync(id, cancellationToken);
}