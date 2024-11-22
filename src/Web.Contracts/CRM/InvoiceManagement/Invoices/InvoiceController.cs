using Forpost.Application.Contracts;
using Forpost.Application.Contracts.ChangeLogs;
using Forpost.Application.Contracts.CRM.InvoiceManagement.Invoices;
using Forpost.Domain.ChangeLogs;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Features.ChangeLogs;
using Forpost.Features.CRM.InvoiceManagement.Invoices;
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
        /// Получить счет по ID
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
            => Ok(await Sender.Send(new GetInvoiceByIdQuery(id), cancellationToken));

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

            var invoiceId = await Sender.Send(new AddInvoiceCommand
            {
                Number = request.Number,
                ContractorId = request.ContractorId,
                Description = request.Description,
                PaymentDeadline = request.PaymentDeadline,
                Priority = Priority.FromValue(request.Priority),
                PaymentStatus = PaymentStatus.FromValue(request.PaymentStatus),
                CreateDate = request.CreateDate,
                PaymentPercentage = request.PaymentPercentage,
                Products = request.Products,
            }, cancellationToken);
            return CreatedAtRoute("", invoiceId);
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
        public async Task<IActionResult> ChangePaymentStatus(Guid id, [FromBody] PaymentStatusRequest request,
            CancellationToken cancellationToken)
        {
            await Sender.Send(new ChangePaymentStatusCommand(id, request.PaymentStatusValue), cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Изменить приоритет счета
        /// </summary>
        [HttpPut("{id}/priority")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ChangePriority(Guid id, [FromBody] PriorityRequest request,
            CancellationToken cancellationToken)
        {
            await Sender.Send(new ChangePriorityCommand(id, request.PriorityValue), cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Отгрузить счет
        /// </summary>
        [HttpPut("{id}/ship")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ShipInvoice(Guid id, [FromBody] DateShipmentRequest request,
            CancellationToken cancellationToken)
        {
            await Sender.Send(new ShipInvoiceCommand(id, request.ShipmentDate), cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Изменить процент оплаты
        /// </summary>
        [HttpPut("{id}/payment-percentage")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> SetPaymentPercentage(Guid id, [FromBody] PaymentPercentageRequest request,
            CancellationToken cancellationToken)
        {
            await Sender.Send(new ChangePaymentPercentageCommand(id, request.PaymentPercentage), cancellationToken);
            return NoContent();
        }
        
        /// <summary>
        /// Получить изменения в счете по ID
        /// </summary>
        [HttpGet("{id}/change-logs")]
        [ProducesResponseType(typeof(EntityPagedResult<ChangeLog>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetChangeLogsByIdAsync(Guid id, [FromQuery] ChangeLogFilter filter,
            CancellationToken cancellationToken)
        {
            return Ok(await Sender.Send(new GetChangeLogsByIdQuery(id, filter), cancellationToken));
        }
        
    }
}