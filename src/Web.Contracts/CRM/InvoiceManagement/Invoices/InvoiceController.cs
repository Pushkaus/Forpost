using Forpost.Application.Contracts;
using Forpost.Application.Contracts.CRM.InvoiceManagement.Invoices;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Features.CRM.InvoiceManagement.Invoices;
using Forpost.Features.InvoiceManagement.Invoices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.CRM.InvoiceManagement.Invoices
{
    /// <summary>
    /// Контроллер для работы со счетами
    /// </summary>
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
        [ProducesResponseType(typeof(EntityPagedResult<InvoiceModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync([FromQuery] InvoiceFilter filter,
            CancellationToken cancellationToken)
        {
            var result = await Sender.Send(new GetAllInvoicesQuery(filter), cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Создать счет
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] InvoiceCreateRequest request,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await Sender.Send(new AddInvoiceCommand
            {
                Number = request.Number,
                ContractorId = request.ContractorId,
                Description = request.Description,
                PaymentDeadline = request.PaymentDeadline,
                Priority = Priority.FromValue(request.Priority),
                PaymentStatus = PaymentStatus.FromValue(request.PaymentStatus),
                Products = request.Products,
            }, cancellationToken);
            return CreatedAtRoute("", id);
        }

        /// <summary>
        /// Удалить счет по его id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await Sender.Send(new DeleteInvoiceCommand(id), cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Изменить статус оплаты счета
        /// </summary>
        [HttpPut("{id}/payment-status")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ChangePaymentStatus(Guid id, [FromBody] int paymentStatus,
            CancellationToken cancellationToken)
        {
            await Sender.Send(new ChangePaymentStatusCommand(id, paymentStatus), cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Изменить приоритет счета
        /// </summary>
        [HttpPut("{id}/priority")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ChangePriority(Guid id, [FromBody] int priority,
            CancellationToken cancellationToken)
        {
            await Sender.Send(new ChangePriorityCommand(id, priority), cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Отгрузить счет
        /// </summary>
        [HttpPut("{id}/ship")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ShipInvoice(Guid id, [FromBody] DateTimeOffset shipDate,
            CancellationToken cancellationToken)
        {
            await Sender.Send(new ShipInvoiceCommand(id, shipDate), cancellationToken);
            return NoContent();
        }
    }
}