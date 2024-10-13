using System.Net.Mime;
using Forpost.Application.Contracts.InvoiceManagment.Invoices;
using Forpost.Domain.InvoiceManagement;
using Forpost.Features.InvoiceManagement.Invoices;
using Forpost.Features.InvoiceManagment.Invoices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.InvoiceManagement.Invoices;

[Route("api/v1/invoices")]
public sealed class InvoiceController : ApiController
{
    /// <summary>
    /// Получить счет по его номеру
    /// </summary>
    [HttpGet("number/{number}")]
    [ProducesResponseType(typeof(Invoice), StatusCodes.Status200OK)]
    public async Task<Invoice> GetByNumberAsync(string number, CancellationToken cancellationToken)
        => await Sender.Send(new GetInvoiceByNumberQuery(number), cancellationToken);

    /// <summary>
    /// Получить все счета
    /// </summary>
    /// <returns>Список счетов</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<InvoiceModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken,
        [FromQuery] int skip = 0, [FromQuery] int limit = 100,
        [FromQuery] string? filterExpression = null, [FromQuery] string?[]? filterValues = null)
    {
        var result = await Sender.Send(new GetAllInvoicesQuery(filterExpression, filterValues, skip, limit),
            cancellationToken);
        return Ok(new { Invoices = result.Invoices, TotalCount = result.TotalCount });
    }

    /// <summary>
    /// Создать счет
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<ActionResult<Guid>> ExposeAsync([FromBody] InvoiceCreateRequest request,
        CancellationToken cancellationToken)
    {
        var id = await Sender.Send(new AddInvoiceCommand
        {
            Number = request.Number,
            ContractorId = request.ContragentId,
            Description = request.Description,
            DaysShipment = request.DaysShipment,
            PaymentPercentage = request.PaymentPercentage,
            Products = request.Products,
        }, cancellationToken);
        return Created("", id);
    }


    // /// <summary>
    // /// Закрытие счета
    // /// </summary>
    // [HttpPut("close/{id}")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // public async Task<IActionResult>
    //     ClosingAsync([FromBody] InvoiceUpdateRequest request, CancellationToken cancellationToken)
    // {
    //     //Todo;
    //     return Ok();
    // } 
    /// <summary>
    /// Закрытие счета, смена статуса и выставление даты отгрузки
    /// </summary>
    [HttpPut("ship/{invoiceId}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult>
        ShipAsync(Guid invoiceId, DateTimeOffset shipDate, CancellationToken cancellationToken)
    {
        await Sender.Send(new ShipInvoiceCommand(invoiceId, shipDate), cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Обновление счета
    /// </summary>
    /// <param name="request"></param>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult>
        UpdateAsync([FromBody] InvoiceUpdateRequest request, CancellationToken cancellationToken)
    {
        //Todo;
        return Ok();
    }

    /// <summary>
    /// Удалить счет по его id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        //Todo;
        return Ok();
    }
}