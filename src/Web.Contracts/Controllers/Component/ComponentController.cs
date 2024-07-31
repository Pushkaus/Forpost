using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.SubProducts;
using Forpost.Web.Contracts.Models.SubProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.Component;
[ApiController]
[Route("api/v1/component")]
[Authorize]
sealed public class ComponentController: ControllerBase
{
    private readonly IComponentService _componentService;
    private readonly IMapper _mapper;
    public ComponentController(IComponentService componentService, IMapper mapper)
    {
        _componentService = componentService;
        _mapper = mapper;
    }

    /// <summary>
    /// Добавление субпродукта
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] SubProductCreateRequest request)
    {
        var model = _mapper.Map<SubProductCreateModel>(request);
        await _componentService.Add(model);
        return Ok();
    }
    /// <summary>
    /// Получить субпродукты 
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SubProductResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProducts(Guid id)
    {
        var storageProducts = await _componentService.GetAllProducts(id);
        var response = _mapper.Map<IReadOnlyList<SubProductResponse>>(storageProducts);
        return Ok(response);
    }
}