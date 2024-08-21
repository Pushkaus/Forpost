using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Steps;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Abstract.Repositories.CreatingProducts;

namespace Forpost.Business.Services;

internal sealed class StepService: IStepService
{
    private readonly IStepRepository _stepRepository;

    private readonly IMapper _mapper;

    public StepService(IStepRepository stepRepository, IMapper mapper)
    {
        _stepRepository = stepRepository;
        _mapper = mapper;
    }

    public async Task<Guid> AddAsync(StepCreateModel model, CancellationToken cancellationToken)
    {
        var step = _mapper.Map<Step>(model);
        return await _stepRepository.AddAsync(step, cancellationToken);
    }

    public async Task<Step?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await _stepRepository.GetByIdAsync(id, cancellationToken);

    public async Task<IReadOnlyList<Step>> GetAllAsync(CancellationToken cancellationToken) 
        => await _stepRepository.GetAllAsync(cancellationToken);

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await _stepRepository.DeleteByIdAsync(id, cancellationToken);
}