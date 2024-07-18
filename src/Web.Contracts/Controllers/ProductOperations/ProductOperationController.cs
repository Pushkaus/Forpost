using System.Collections;
using System.Security.Claims;
using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.ProductOperations;
using Forpost.Store.Entities;
using Forpost.Web.Contracts.Models.ProductOperations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.ProductOperations;
[ApiController]
[Route("api/v1/product-operation")]
[Authorize]
sealed public class ProductOperationController: ControllerBase
{
    private readonly IProductOperationService _productOperationService;
    private readonly IMapper _mapper;
    public ProductOperationController(IProductOperationService productOperationService, IMapper mapper)
    {
        _productOperationService = productOperationService;
        _mapper = mapper;
    }

    /// <summary>
    /// Создать операцию над продуктом
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromQuery]OperationCreateRequest request)
    {
        var model = _mapper.Map<OperationCreateModel>(request);
        await _productOperationService.Add(model);
        return Ok();
    }

    /// <summary>
    /// Получить все операции над продуктом по его id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllByProductId(Guid id)
    {
        var productOperations = await _productOperationService.GetAllByProductId(id);
        return Ok(productOperations);
    }
    ///TODO 
}