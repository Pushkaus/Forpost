using AutoMapper;
using Forpost.Features.FileStorage.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.FIleStorage;

[Route("api/v1/files")]
[Authorize]
public sealed class FileController : ApiController
{
    private readonly IMapper _mapper;

    public FileController(IMapper mapper)
    {
        _mapper = mapper;
    }

    /// <summary>
    /// Добавление файлов к id
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
        
        var id = await Sender.Send(
            new UploadFileCommand(request.File.FileName, content, request.File.ContentType, request.ParentId), cancellationToken);
        return Ok(id);
    }

    /// <summary>
    /// Скачивание файла с сервера
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DownloadFileResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> DownloadFileAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await Sender.Send(new DownloadFileQuery(id), cancellationToken);
        var downloadFile = _mapper.Map<DownloadFileResponse>(response);
        return Ok(downloadFile);
    }

    /// <summary>
    /// Удаление файла из БД
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DownloadFileResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteFileAsync(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteFileByIdCommand(id), cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Список файлов по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{parentId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<FileResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllFilesAsync(Guid parentId, CancellationToken cancellationToken)
    {
        var files = await Sender.Send(new GetAllFileInfosByProductIdQuery(parentId), cancellationToken);
        return Ok(files);
    }
}