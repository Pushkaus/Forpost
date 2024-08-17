using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Storages;
using Forpost.Web.Contracts.Models.StorageProduct;
using Forpost.Web.Contracts.Models.Storages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.Storage;
[ApiController]
[Route("api/v1/storages")]
[Authorize]
sealed public class StorageController: ControllerBase
{
    private readonly IStorageService _storageService;
    private readonly IMapper _mapper;

    public StorageController(IStorageService storageService, IMapper mapper)
    {
        _storageService = storageService;
        _mapper = mapper;
    }
    /// <summary>
    /// Создание нового склада
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult>
        CreateAsync([FromBody] StorageCreateRequest request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<StorageCreateModel>(request);
        await _storageService.AddAsync(model, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получить список всех складов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(StorageReponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var storages = await _storageService.GetAllAsync(cancellationToken);
        return Ok(storages);
    }
}