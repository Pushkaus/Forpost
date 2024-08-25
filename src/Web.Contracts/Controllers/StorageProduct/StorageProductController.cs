// using AutoMapper;
// using Forpost.Business.Sortout;
// using Forpost.Web.Contracts.Models.StorageProduct;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Forpost.Web.Contracts.Controllers.StorageProduct;
//
// [ApiController]
// [Route("api/v1/storage-products")]
// [Authorize]
// public sealed class StorageProductController : ControllerBase
// {
//     private readonly IMapper _mapper;
//     private readonly IStorageProductService _storageProductService;
//
//     public StorageProductController(IStorageProductService storageProductService, IMapper mapper)
//     {
//         _storageProductService = storageProductService;
//         _mapper = mapper;
//     }
//
//     /// <summary>
//     /// Получить список всех продуктов
//     /// </summary>
//     /// <returns></returns>
//     [HttpGet("{id}")]
//     [ProducesResponseType(typeof(IReadOnlyCollection<StorageProductResponse>), StatusCodes.Status200OK)]
//     public async Task<IActionResult> GetAllProductsAsync(Guid id, CancellationToken cancellationToken)
//     {
//         var storageProducts = await _storageProductService.GetAllProductsAsync(id, cancellationToken);
//         var response = _mapper.Map<IList<StorageProductResponse>>(storageProducts);
//         return Ok(response);
//     }
//
//     /// <summary>
//     /// Добавить продукт на склад
//     /// </summary>
//     /// <param name="request"></param>
//     /// <returns></returns>
//     [HttpPost]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     public async Task<IActionResult>
//         CreateAsync([FromBody] StorageProductCreateRequest request, CancellationToken cancellationToken)
//     {
//         var model = _mapper.Map<StorageProductCreateCommand>(request);
//         await _storageProductService.AddAsync(model, cancellationToken);
//         return Ok();
//     }
//
//     /// <summary>
//     /// Получение информации о продукте на складе
//     /// </summary>
//     /// <param name="request"></param>
//     /// <returns></returns>
//     [HttpGet("product-{id}")]
//     [ProducesResponseType(typeof(StorageProductResponse), StatusCodes.Status200OK)]
//     public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
//     {
//         var storageProduct = await _storageProductService.GetByIdAsync(id, cancellationToken);
//         return Ok(storageProduct);
//     }
//
//     /// <summary>
//     /// Обновление продукта на складе
//     /// </summary>
//     /// <param name="request"></param>
//     /// <returns></returns>
//     [HttpPut]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     public async Task<IActionResult>
//         UpdateAsync([FromBody] StorageProductCreateRequest request, CancellationToken cancellationToken)
//     {
//         var model = _mapper.Map<StorageProductCreateCommand>(request);
//         await _storageProductService.UpdateAsync(model, cancellationToken);
//         return Ok();
//     }
// }