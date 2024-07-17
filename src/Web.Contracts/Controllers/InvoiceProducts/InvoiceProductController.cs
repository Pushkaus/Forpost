using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.InvoiceProducts;
using Forpost.Web.Contracts.Models.InvoiceProducts;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.InvoiceProducts;
[ApiController]
[Route("api/v1/invoice-products")]
public class InvoiceProductController: ControllerBase
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
    public async Task<IActionResult> Create([FromQuery] InvoiceProductRequest request)
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
    public async Task<IActionResult> Update([FromQuery] InvoiceProductRequest request)
    {
        var model = _mapper.Map<InvoiceProductCreateModel>(request);
        await _invoiceProductService.Update(model);
        return Ok();
    }
}