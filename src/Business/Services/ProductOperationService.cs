using System.Collections;
using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.ProductOperations;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Models.ProductOperation;

namespace Forpost.Business.Services;

public sealed class ProductOperationService: IProductOperationService
{
    private readonly IProductOperationRepository _productOperationRepository;
    private readonly IMapper _mapper;
    public ProductOperationService(IProductOperationRepository productOperationRepository, IMapper mapper)
    {
        _productOperationRepository = productOperationRepository;
        _mapper = mapper;
    }


    public async Task Add(OperationCreateModel model)
    {
        var operation = _mapper.Map<ProductOperation>(model);
        await _productOperationRepository.AddAsync(operation);
        
    }

    public async Task<IReadOnlyList<ProductOperation>> GetAll()
    {
        return await _productOperationRepository.GetAllAsync();
    }
    public async Task<IReadOnlyList<ProductOperation>> GetAllByProductId(Guid id)
    {
        return await _productOperationRepository.GetAllByProductId(id);
    }
}