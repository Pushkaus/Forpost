using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Files;
using Forpost.Web.Contracts.Models.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.Controllers.FIles;

[ApiController]
[Route("api/v1/files")]
[Authorize]
public sealed class FileController : ControllerBase
{
    private readonly IFileService _fileService;

    private readonly IMapper _mapper;

    public FileController(IFileService fileService, IMapper mapper)
    {
        _fileService = fileService;
        _mapper = mapper;
    }

    /// <summary>
    ///     Добавление файлов к id
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> UploadFileAsync(UploadFileRequest request, CancellationToken cancellationToken)
    {
        if (request.File.Length == 0)
            return BadRequest();

        byte[] content;
        using (var memoryStream = new MemoryStream())
        {
            await request.File.CopyToAsync(memoryStream);
            content = memoryStream.ToArray();
        }

        var model = _mapper.Map<UploadFileModel>(request);
        model.Content = content;
        var id = await _fileService.UploadFileAsync(model, cancellationToken);
        return Ok(id);
    }

    /// <summary>
    ///     Скачивание файла с сервера
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DownloadFileResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> DownloadFileAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _fileService.DownloadFileAsync(id, cancellationToken);
        var downloadFile = _mapper.Map<DownloadFileResponse>(response);
        return Ok(downloadFile);
    }

    /// <summary>
    ///     Удаление файла из БД
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DownloadFileResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteFileAsync(Guid id, CancellationToken cancellationToken)
    {
        await _fileService.DeleteFileAsync(id, cancellationToken);
        return Ok();
    }

    /// <summary>
    ///     Список файлов по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("get-all-files/{parentId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<FileResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllFilesAsync(Guid parentId, CancellationToken cancellationToken)
    {
        var files = await _fileService.GetAllFilesAsync(parentId, cancellationToken);
        return Ok(files);
    }
}