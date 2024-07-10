using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.SubProducts;
using Forpost.Web.Contracts.Models.SubProducts;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.SubProduct;
[ApiController]
[Route("api/v1/sub-product")]
public class SubProductController: ControllerBase
{
    private readonly ISubProductService _subProductService;
    private readonly IMapper _mapper;
    public SubProductController(ISubProductService subProductService, IMapper mapper)
    {
        _subProductService = subProductService;
        _mapper = mapper;
    }

    /// <summary>
    /// Добавление субпродукта
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromQuery] SubProductCreateRequest request)
    {
        var model = _mapper.Map<SubProductCreateModel>(request);
        await _subProductService.Add(model);
        return Ok();
    }
    /// <summary>
    /// Получить субпродукты 
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllProducts(Guid id)
    {
        var storageProducts = await _subProductService.GetAllProducts(id);
        var response = _mapper.Map<IReadOnlyList<SubProductResponse>>(storageProducts);
        return Ok(response);
    }
}