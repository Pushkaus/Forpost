using System.Security.Claims;
using Forpost.Business.Abstract.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Storage;
[ApiController]
[Route("api/v1/storages")]
[Authorize]
public class StorageController: ControllerBase
{
    private readonly IStorageService _storageService;

    public StorageController(IStorageService storageService)
    {
        _storageService = storageService;
    }
    [HttpPut("create-storage")]
    public async Task<IActionResult> CreateStorageAsync(string storageName, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(storageName))
        {
            return BadRequest("Storage name cannot be null or empty.");
        }
        var user = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var userId = Guid.Parse(user);
        var responsibleId = userId;
        // Вызов сервиса создания storage
        var result = await _storageService.CreateStorageAsync(storageName, userId, responsibleId, cancellationToken);
        return Ok(result);
    }
}