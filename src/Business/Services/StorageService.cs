using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Web.Contracts.Models.Storages;

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