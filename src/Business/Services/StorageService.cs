using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Storages;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

internal sealed class StorageService: IStorageService
{
    private readonly IStorageRepository _storageRepository;
    private readonly IMapper _mapper;
    public StorageService(IStorageRepository storageRepository, IMapper mapper)
    {
        _storageRepository = storageRepository;
        _mapper = mapper;
    }

    public async Task Add(StorageCreateModel model)
    {
        var storage = _mapper.Map<Storage>(model);
        await _storageRepository.AddAsync(storage);
    }

    public async Task<IReadOnlyList<Storage?>> GetAll()
    {
        return await _storageRepository.GetAllAsync();
    }
}