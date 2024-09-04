using System.Net.Mime;
using Forpost.Domain.InvoiceManagement;
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
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<Invoice>), StatusCodes.Status200OK)]
    public async Task<IReadOnlyCollection<Invoice>> GetAllAsync(CancellationToken cancellationToken) 
        => await Sender.Send(new GetAllInvoicesQuery(), cancellationToken);

    /// <summary>
    /// Создать счет
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<Guid>
        ExposeAsync([FromBody] InvoiceCreateRequest request, CancellationToken cancellationToken)
    {
        return await Sender.Send(new AddInvoiceCommand
        {
            Number = request.Number,
            ContragentId = request.ContragentId,
            Description = request.Description,
            DaysShipment = request.DaysShipment,
            PaymentPercentage = request.PaymentPercentage,
            Products = request.Products,
        }, cancellationToken);
    }

    /// <summary>
    /// Закрытие счета
    /// </summary>
    [HttpPut("close/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult>
        ClosingAsync([FromBody] InvoiceUpdateRequest request, CancellationToken cancellationToken)
    {
        //Todo;
        return Ok();
    } 
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