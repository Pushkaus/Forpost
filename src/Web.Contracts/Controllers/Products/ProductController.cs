using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Products;
using Forpost.Web.Contracts.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.Products;
[ApiController]
[Route("api/v1/products")]
[Authorize]
sealed public class ProductController: ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    /// <summary>
    /// Получение всех продуктов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ProductResponse>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAll();
        return Ok(products);
    }

    /// <summary>
    /// Получение продукта по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _productService.GetById(id);
        return Ok(product);
    }

    /// <summary>
    /// Создать продукт
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] ProductCreateRequest request)
    {
        var model = _mapper.Map<ProductCreateModel>(request);
        var id = await _productService.Add(model);
        return Ok(id);
    }

    /// <summary>
    /// Обновление продукта по id
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] ProductUpdateRequest request)
    {
       var model = _mapper.Map<ProductUpdateModel>(request);
       await _productService.Update(model);
       return Ok();
    }

    /// <summary>
    /// Удаление продукта по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _productService.Delete(id);
        return Ok();
    }
}