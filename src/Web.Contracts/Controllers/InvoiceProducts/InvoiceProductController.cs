using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.InvoiceProducts;
using Forpost.Web.Contracts.Models.InvoiceProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.InvoiceProducts;
[ApiController]
[Route("api/v1/invoice-products")]
[Authorize]
sealed public class InvoiceProductController: ControllerBase
{
    private readonly IInvoiceProductService _invoiceProductService;
    private readonly IMapper _mapper;
    public InvoiceProductController(IInvoiceProductService invoiceProductService, IMapper mapper)
    {
        _invoiceProductService = invoiceProductService;
        _mapper = mapper;
    }

    /// <summary>
    /// Добавление продуктов в счет
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] InvoiceProductRequest request)
    {
        var model = _mapper.Map<InvoiceProductCreateModel>(request);
        await _invoiceProductService.Add(model);
        return Ok();
    }

    /// <summary>
    /// Получение продуктов по id счета
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<InvoiceProductResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProductsById(Guid id)
    {
        var products = await _invoiceProductService.GetProductsById(id);
        var model = _mapper.Map<List<InvoiceProductResponse>>(products);
        return Ok(model);
    }

    /// <summary>
    /// Обновление продукта в счете
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] InvoiceProductRequest request)
    {
        var model = _mapper.Map<InvoiceProductCreateModel>(request);
        await _invoiceProductService.Update(model);
        return Ok();
    }

    /// <summary>
    /// Удаление продукта из счета
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _invoiceProductService.DeleteByProductId(id);
        return Ok();
    }
}