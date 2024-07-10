using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.StorageProduct;
using Forpost.Web.Contracts.Models.StorageProduct;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.StorageProduct;
[ApiController]
[Route("api/v1/storage-products")]
public class StorageProductController: ControllerBase
{
    private readonly IStorageProductService _storageProductService;
    private readonly IMapper _mapper;

    public StorageProductController(IStorageProductService storageProductService, IMapper mapper)
    {
        _storageProductService = storageProductService;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить список всех продуктов
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllProducts(Guid id)
    {
        var storageProducts = await _storageProductService.GetAllProducts(id);
        var response = _mapper.Map<IList<StorageProductResponse>>(storageProducts);
        return Ok(response);
    }

    /// <summary>
    /// Добавить продукт на склад
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromQuery] StorageProductCreateRequest request)
    {
        var model = _mapper.Map<StorageProductCreateModel>(request);
        await _storageProductService.Add(model);
        return Ok();
    }
    
}