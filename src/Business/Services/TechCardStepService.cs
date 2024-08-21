using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.TechCardSteps;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

internal sealed class TechCardStepService: ITechCardStepService
{
    private readonly ITechCardStepRepositrory _techCardStepRepositrory;
    private readonly IMapper _mapper;

    public TechCardStepService(ITechCardStepRepositrory techCardStepRepositrory, IMapper mapper)
    {
        _techCardStepRepositrory = techCardStepRepositrory;
        _mapper = mapper;
    }

    public async Task<Guid> AddAsync(TechCardStepCreateModel model, CancellationToken cancellationToken)
    {
        var techCardStep = _mapper.Map<TechCardStep>(model);
        return await _techCardStepRepositrory.AddAsync(techCardStep, cancellationToken);
    }

    public async Task<TechCardStep?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await _techCardStepRepositrory.GetByIdAsync(id, cancellationToken);

    public async Task<IReadOnlyCollection<StepsInTechCardModel>> GetStepsByTechCardIdAsync
        (Guid techCardId, CancellationToken cancellationToken)
    {
        var model = await _techCardStepRepositrory.GetAllStepsByTechCardId(techCardId, cancellationToken);
        var result = _mapper.Map<IReadOnlyCollection<StepsInTechCardModel>>(model);
        return result;
    }

    public async Task<IReadOnlyList<TechCardStep>> GetAllAsync(CancellationToken cancellationToken) 
        => await _techCardStepRepositrory.GetAllAsync(cancellationToken);

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _techCardStepRepositrory.DeleteByIdAsync(id, cancellationToken);
}