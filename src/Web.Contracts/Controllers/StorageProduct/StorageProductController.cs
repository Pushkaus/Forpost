using System.Runtime.InteropServices;
using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.StorageProduct;
using Forpost.Web.Contracts.Models.StorageProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.StorageProduct;
[ApiController]
[Route("api/v1/storage-products")]
[Authorize]
sealed public class StorageProductController: ControllerBase
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
    public async Task<IActionResult> Create([FromBody] StorageProductCreateRequest request)
    {
        var model = _mapper.Map<StorageProductCreateModel>(request);
        await _storageProductService.Add(model);
        return Ok();
    }
    
    /// <summary>
    /// Получение информации о продукте на складе
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("product-{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var storageProduct = await _storageProductService.GetById(id);
        return Ok(storageProduct);
    }
    /// <summary>
    /// Обновление продукта на складе
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] StorageProductCreateRequest request)
    {
        var model = _mapper.Map<StorageProductCreateModel>(request);
        await _storageProductService.Update(model);
        return Ok();
    }
}