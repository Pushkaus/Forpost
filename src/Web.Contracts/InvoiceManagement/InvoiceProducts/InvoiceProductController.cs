using Forpost.Features.InvoiceManagment.InvoiceProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.InvoiceManagement.InvoiceProducts;

[Route("api/v1/invoice-products")]
public sealed class InvoiceProductController : ApiController
{
    /// <summary>
    /// Добавление продуктов в счет
    /// </summary>
    /// <param name="request"></param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult>
        CreateAsync([FromBody] InvoiceProductRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(new AddInvoiceProductCommand(
            request.InvoiceId,
            request.ProductId,
            request.Quantity), cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение продуктов по id счета
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<InvoiceProductResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCompositionInvoiceAsync(Guid id, CancellationToken cancellationToken)
    {
        var compositionInvoice = await Sender.Send(new GetCompositionInvoiceQuery(id), cancellationToken);
        var result = Mapper.Map<IReadOnlyCollection<InvoiceProductResponse>>(compositionInvoice);
        return Ok(result);
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