// using AutoMapper;
// using Forpost.Domain.Sortout;
// using Forpost.Web.Contracts.Models.InvoiceProducts;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Forpost.Web.Contracts.Controllers.InvoiceProducts;
//
// [ApiController]
// [Route("api/v1/invoice-products")]
// [Authorize]
// public sealed class InvoiceProductController : ControllerBase
// {
//     private readonly IInvoiceProductService _invoiceProductService;
//     private readonly IMapper _mapper;
//
//     public InvoiceProductController(IInvoiceProductService invoiceProductService, IMapper mapper)
//     {
//         _invoiceProductService = invoiceProductService;
//         _mapper = mapper;
//     }
//
//     /// <summary>
//     /// Добавление продуктов в счет
//     /// </summary>
//     /// <param name="request"></param>
//     /// <returns></returns>
//     [HttpPost]
//     [ProducesResponseType(StatusCodes.Status201Created)]
//     public async Task<IActionResult>
//         CreateAsync([FromBody] InvoiceProductRequest request, CancellationToken cancellationToken)
//     {
//         var model = _mapper.Map<InvoiceProductCreate>(request);
//         await _invoiceProductService.AddAsync(model, cancellationToken);
//         return Ok();
//     }
//
//     /// <summary>
//     /// Получение продуктов по id счета
//     /// </summary>
//     /// <param name="id"></param>
//     /// <returns></returns>
//     [HttpGet("{id}")]
//     [ProducesResponseType(typeof(IReadOnlyCollection<InvoiceProductResponse>), StatusCodes.Status200OK)]
//     public async Task<IActionResult> GetAllProductsByIdAsync(Guid id, CancellationToken cancellationToken)
//     {
//         var products = await _invoiceProductService.GetProductsByInvoiceIdAsync(id, cancellationToken);
//         var model = _mapper.Map<List<InvoiceProductResponse>>(products);
//         return Ok(model);
//     }
//
//     /// <summary>
//     /// Обновление продукта в счете
//     /// </summary>
//     /// <param name="request"></param>
//     /// <returns></returns>
//     [HttpPut]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     public async Task<IActionResult>
//         UpdateAsync([FromBody] InvoiceProductRequest request, CancellationToken cancellationToken)
//     {
//         var model = _mapper.Map<InvoiceProductCreate>(request);
//         await _invoiceProductService.UpdateAsync(model, cancellationToken);
//         return Ok();
//     }
//
//     /// <summary>
//     /// Удаление продукта из счета
//     /// </summary>
//     /// <param name="id"></param>
//     /// <returns></returns>
//     [HttpDelete("{id}")]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
//     {
//         await _invoiceProductService.DeleteByProductIdAsync(id, cancellationToken);
//         return Ok();
//     }
// }