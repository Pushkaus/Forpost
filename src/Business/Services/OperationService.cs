using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Operations;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

internal sealed class OperationService: IOperationService
{
    private readonly IOperationRepository _operationRepository;

    private readonly IMapper _mapper;

    public OperationService(IOperationRepository operationRepository, IMapper mapper)
    {
        _operationRepository = operationRepository;
        _mapper = mapper;
    }

    public async Task<Guid> AddAsync(OperationModel model, CancellationToken cancellationToken)
    {
        var operation = _mapper.Map<Operation>(model);
        return await _operationRepository.AddAsync(operation, cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken) 
        => await _operationRepository.DeleteByIdAsync(id, cancellationToken);

    public async Task<IReadOnlyCollection<Operation>> GetAllAsync(CancellationToken cancellationToken) 
        => await _operationRepository.GetAllAsync(cancellationToken);
}