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
public sealed class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;
    private readonly IMapper _mapper;

    public InvoiceController(IInvoiceService invoiceService, IMapper mapper)
    {
        _invoiceService = invoiceService;
        _mapper = mapper;
    }

    /// <summary>
    ///     Получить счет по его номеру
    /// </summary>
    [HttpGet("{number}")]
    [ProducesResponseType(typeof(InvoiceResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByNumberAsync(string number, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceService.GetByNumberAsync(number, cancellationToken);
        return Ok(invoice);
    }

    /// <summary>
    ///     Получить все счета
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<InvoiceResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var invoices = await _invoiceService.GetAllAsync(cancellationToken);
        return Ok(invoices);
    }

    /// <summary>
    ///     Создать счет
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid>
        ExposeAsync([FromBody] InvoiceCreateRequest request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<InvoiceCreateModel>(request);
        var id = await _invoiceService.ExposeAsync(model, cancellationToken);
        return id;
    }

    /// <summary>
    ///     Закрытие счета, смена статуса и выставление даты отгрузки
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("close/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult>
        ClosingAsync([FromBody] InvoiceUpdateRequest request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<InvoiceUpdateModel>(request);
        await _invoiceService.CloseAsync(model, cancellationToken);
        return Ok();
    }

    /// <summary>
    ///     Обновление счета
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult>
        UpdateAsync([FromBody] InvoiceUpdateRequest request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<InvoiceUpdateModel>(request);
        await _invoiceService.UpdateAsync(model, cancellationToken);
        return Ok();
    }

    /// <summary>
    ///     Удалить счет по его id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _invoiceService.DeleteByIdAsync(id, cancellationToken);
        return Ok();
    }
}