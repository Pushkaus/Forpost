using AutoMapper;
using Forpost.Features.FileStorage.Files;
using Forpost.Web.Contracts.FIleStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts.FileStorage;

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
    /// Добавление файла
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadFileAsync(UploadFileRequest request, CancellationToken cancellationToken)
    {
        if (request.File.Length == 0)
            return BadRequest("Файл не может быть пустым.");

        using var memoryStream = new MemoryStream();
        await request.File.CopyToAsync(memoryStream, cancellationToken);
        var content = memoryStream.ToArray();

        var id = await Sender.Send(
            new UploadFileCommand(request.File.FileName, content, request.File.ContentType, request.ParentId), cancellationToken);
        return CreatedAtRoute(nameof(UploadFileAsync), new { id }, id);
    }

    /// <summary>
    /// Скачивание файла с сервера
    /// </summary>
    [HttpGet("download/{id}")]
    [ProducesResponseType(typeof(DownloadFileResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DownloadFileAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await Sender.Send(new DownloadFileQuery(id), cancellationToken);
        if (response == null)
        {
            return NotFound("Файл не найден.");
        }

        var downloadFile = _mapper.Map<DownloadFileResponse>(response);
        return File(downloadFile.FileContent, downloadFile.ContentType, downloadFile.FileName);
    }

    /// <summary>
    /// Удаление файла из БД
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteFileAsync(Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteFileByIdCommand(id), cancellationToken);
        return NoContent(); // Возвращаем 204 No Content
    }

    /// <summary>
    /// Получение списка файлов по родительскому идентификатору
    /// </summary>
    [HttpGet("{parentId}")]
    [ProducesResponseType(typeof(IReadOnlyCollection<FilesResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllFilesAsync(Guid parentId, CancellationToken cancellationToken)
    {
        var files = await Sender.Send(new GetAllFileInfosByProductIdQuery(parentId), cancellationToken);
        if (files == null || !files.Any())
        {
            return NotFound("Файлы не найдены для данного идентификатора родителя.");
        }
        return Ok(files);
    }
}
