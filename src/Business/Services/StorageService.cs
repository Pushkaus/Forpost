using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Storages;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

internal sealed class StorageService : IStorageService
{
    private readonly IMapper _mapper;
    private readonly IStorageRepository _storageRepository;

    public StorageService(IStorageRepository storageRepository, IMapper mapper)
    {
        _storageRepository = storageRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(StorageCreateModel model, CancellationToken cancellationToken)
    {
        var storage = _mapper.Map<Storage>(model);
        await _storageRepository.AddAsync(storage, cancellationToken);
    }

    public async Task<IReadOnlyList<Storage?>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _storageRepository.GetAllAsync(cancellationToken);
    }
}