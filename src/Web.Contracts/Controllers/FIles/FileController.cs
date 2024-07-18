using Forpost.Business.Abstract.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.FIles;
[ApiController]
[Route("api/v1/files")]
public sealed class FileController: ControllerBase
{
    private readonly IFilesService _filesService;
    public FileController(IFilesService filesService)
    {
        _filesService = filesService;
    }    
    /// <summary>
    /// Добавление файлов к id 
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> UploadFile(Guid parentId, IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        byte[] content;
        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            content = memoryStream.ToArray();
        }
        await _filesService.UploadFile(parentId, file.FileName, file.ContentType, content);
        return Ok();
    }

    /// <summary>
    /// Скачивание файла с сервера
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> DownloadFile(Guid id)
    {
        var (fileContent, contentType, fileName) = await _filesService.DownloadFile(id);
        return Ok(File(fileContent, contentType, fileName));
    }
    /// <summary>
    /// Удаление файла из БД 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFile(Guid id)
    {
        await _filesService.DeleteFile(id);
        return Ok();
    }
    /// <summary>
    /// Список файлов по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("get-all-files/{parentId}")]
    public async Task<IActionResult> GetAllFiles(Guid parentId)
    {
        var files = await _filesService.GetAllFiles(parentId);
        return Ok(files);
    }

}