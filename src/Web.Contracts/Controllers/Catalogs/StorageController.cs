// using AutoMapper;
// using Forpost.Domain.Catalogs.Storages;
// using Forpost.Web.Contracts.Models.StorageProduct;
// using Forpost.Web.Contracts.Models.Storages;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Forpost.Web.Contracts.Controllers.Catalogs.Storage;
//
// [ApiController]
// [Route("api/v1/storages")]
// [Authorize]
// public sealed class StorageController : ControllerBase
// {
//     private readonly IMapper _mapper;
//     private readonly IStorageService _storageService;
//
//     public StorageController(IStorageService storageService, IMapper mapper)
//     {
//         _storageService = storageService;
//         _mapper = mapper;
//     }
//
//     /// <summary>
//     /// Создание нового склада
//     /// </summary>
//     /// <param name="request"></param>
//     /// <returns></returns>
//     [HttpPost]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     public async Task<IActionResult>
//         CreateAsync([FromBody] StorageCreateRequest request, CancellationToken cancellationToken)
//     {
//         var model = _mapper.Map<StorageCreateCommand>(request);
//         await _storageService.AddAsync(model, cancellationToken);
//         return Ok();
//     }
//
//     /// <summary>
//     /// Получить список всех складов
//     /// </summary>
//     /// <returns></returns>
//     [HttpGet]
//     [ProducesResponseType(typeof(StorageReponse), StatusCodes.Status200OK)]
//     public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
//     {
//         var storages = await _storageService.GetAllAsync(cancellationToken);
//         return Ok(storages);
//     }
// }