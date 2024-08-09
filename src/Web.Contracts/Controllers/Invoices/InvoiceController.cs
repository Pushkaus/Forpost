using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Invoices;
using Forpost.Web.Contracts.Models.Invoices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.Invoices;
[ApiController]
[Route("api/v1/invoices")]
[Produces("application/json")]
[Authorize]
sealed public class InvoiceController: ControllerBase
{
    private readonly IInvoiceService _invoiceService;
    private readonly IMapper _mapper;
    public InvoiceController(IInvoiceService invoiceService, IMapper mapper)
    {
        _invoiceService = invoiceService;
        _mapper = mapper;
    }
    /// <summary>
    /// Получить счет по его номеру
    /// </summary>
    [HttpGet("{number}")]
    [ProducesResponseType(typeof(InvoiceResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByNumber(string number)
    {
        var invoice = await _invoiceService.GetByNumber(number);
        return Ok(invoice);
    }

    /// <summary>
    /// Получить все счета
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<InvoiceResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var invoices = await _invoiceService.GetAll();
        return Ok(invoices);
    }

    /// <summary>
    /// Создать счет
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Expose([FromBody] InvoiceCreateRequest request)
    {
        var model = _mapper.Map<InvoiceCreateModel>(request);
        var id = await _invoiceService.Expose(model);
        return Ok(id);
    }

    /// <summary>
    /// Закрытие счета, смена статуса и выставление даты отгрузки
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("close/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Closing([FromBody] InvoiceUpdateRequest request)
    {
        var model = _mapper.Map<InvoiceUpdateModel>(request);
        await _invoiceService.Closing(model);
        return Ok();
    }
    /// <summary>
    /// Обновление счета
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] InvoiceUpdateRequest request)
    {
        var model = _mapper.Map<InvoiceUpdateModel>(request);
        await _invoiceService.Update(model);
        return Ok();
    }

    /// <summary>
    /// Удалить счет по его id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public async Task<IActionResult> Delete(Guid id)
    {
        await _invoiceService.DeleteById(id);
        return Ok();
    }
    
    
}