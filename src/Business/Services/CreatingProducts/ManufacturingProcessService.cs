using AutoMapper;
using Forpost.Business.Abstract.Services.CreatingProducts;
using Forpost.Business.Models.ManufacturingProcesses;
using Forpost.Store.Entities.ProductCreating;
using Forpost.Store.Repositories.Abstract.Repositories.CreatingProducts;

namespace Forpost.Business.Services.CreatingProducts;

internal sealed class ManufacturingProcessService: IManufacturingProcessService
{
    private readonly IManufacturingProcessRepository _manufacturingProcessRepository;

    private readonly IMapper _mapper;

    public ManufacturingProcessService(IManufacturingProcessRepository manufacturingProcessRepository, IMapper mapper)
    {
        _manufacturingProcessRepository = manufacturingProcessRepository;
        _mapper = mapper;
    }

    public async Task<Guid> AddAsync(ManufacturingProcessCreateModel model, CancellationToken cancellationToken)
    {
        var manufacturingProcess = _mapper.Map<ManufacturingProcess>(model);
        return await _manufacturingProcessRepository.AddAsync(manufacturingProcess, cancellationToken);
    }

    public async Task<ManufacturingProcess?> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await _manufacturingProcessRepository.GetByIdAsync(id, cancellationToken);

    public async Task<IReadOnlyList<ManufacturingProcess>> GetAllAsync(CancellationToken cancellationToken) 
        => await _manufacturingProcessRepository.GetAllAsync(cancellationToken);

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await _manufacturingProcessRepository.DeleteByIdAsync(id, cancellationToken);
}