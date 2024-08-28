using Forpost.Application.InvoiceManagment.InvoiceProducts;
using Forpost.Web.Contracts.Models.InvoiceProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.InvoiceProducts;

[Route("api/v1/invoice-products")]
public sealed class InvoiceProductController : ApiController
{
    /// <summary>
    /// Добавление продуктов в счет
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult>
        CreateAsync([FromBody] InvoiceProductRequest request, CancellationToken cancellationToken)
    {
        await Mediator.Send(new AddInvoiceProductCommand(
            request.InvoiceId,
            request.ProductId,
            request.Quantity), cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение продуктов по id счета
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<InvoiceProductResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCompositionInvoiceAsync(Guid id, CancellationToken cancellationToken)
    {
        var compositionInvoice = await Mediator.Send(new GetCompositionInvoiceQuery(id), cancellationToken);
        return Ok(compositionInvoice);
    }
    //TODO;
    // /// <summary>
    // /// Обновление продукта в счете
    // /// </summary>
    // /// <param name="request"></param>
    // /// <returns></returns>
    // [HttpPut]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // public async Task<IActionResult>
    //     UpdateAsync([FromBody] InvoiceProductRequest request, CancellationToken cancellationToken)
    // {
    //     var model = _mapper.Map<InvoiceProductCreate>(request);
    //     await _invoiceProductService.UpdateAsync(model, cancellationToken);
    //     return Ok();
    // }
    //
    // /// <summary>
    // /// Удаление продукта из счета
    // /// </summary>
    // /// <param name="id"></param>
    // /// <returns></returns>
    // [HttpDelete("{id}")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    // {
    //     await _invoiceProductService.DeleteByProductIdAsync(id, cancellationToken);
    //     return Ok();
    // }
}