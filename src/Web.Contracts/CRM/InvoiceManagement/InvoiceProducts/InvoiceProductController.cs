using Forpost.Application.Contracts.CRM.InvoiceManagement.CompositionInvoices;
using Forpost.Features.CRM.InvoiceManagement.CompositionInvoices;
using Forpost.Features.CRM.InvoiceManagement.InvoiceProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.CRM.InvoiceManagement.InvoiceProducts;

[Route("api/v1/invoice-products")]
public sealed class InvoiceProductController : ApiController
{
    /// <summary>
    /// Добавление продуктов в счет
    /// </summary>
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
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<InvoiceProductResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCompositionInvoiceAsync(Guid id, CancellationToken cancellationToken)
    {
        var compositionInvoice = await Sender.Send(new GetCompositionInvoiceQuery(id), cancellationToken);
        var result = Mapper.Map<IReadOnlyCollection<InvoiceProductResponse>>(compositionInvoice);
        return Ok(result);
    }
    
    /// <summary>
    /// Заполнение состава счета
    /// </summary>
    [HttpPost("composition")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SetCompositionInvoice([FromBody] CompositionInvoiceRequest request,
        CancellationToken cancellationToken)
    {
        await Sender.Send(
            new AddCompositionInvoiceCommand(request.InvoiceId, request.ProductId, request.CompletedProductIds),
            cancellationToken);
        return Ok();
    }
    /// <summary>
    /// Получение состава счета
    /// </summary>
    [HttpGet("{invoiceId}/composition")]
    [ProducesResponseType(typeof(IReadOnlyCollection<CompositionInvoiceModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCompositionInvoice(Guid invoiceId, CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetCompletedCompositionInvoiceQuery(invoiceId), cancellationToken));
    }
}