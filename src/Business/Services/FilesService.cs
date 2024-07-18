using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Forpost.Business.Services
{
    public class FilesService : IFilesService
    {
        private readonly IFilesRepository _filesRepository;
        private readonly string? _uploadFilePath;
        private readonly IConfiguration _configuration;

        public FilesService(IFilesRepository filesRepository, IConfiguration configuration)
        {
            _filesRepository = filesRepository;
            _configuration = configuration;
            _uploadFilePath = _configuration.GetValue<string>("FileStorage:UploadFilePath");
        }

        public async Task UploadFile(Guid parentId, string fileName, string contentType, byte[] content)
        {
            // Генерация пути к файлу на сервере
            var filePath = Path.Combine(parentId.ToString(), $"{Guid.NewGuid()}{Path.GetExtension(fileName)}");

            // Создание директории, если она не существует
            var fullPath = Path.Combine(_uploadFilePath, filePath);
            var directory = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Запись файла на диск
            await System.IO.File.WriteAllBytesAsync(fullPath, content);

            // Создание сущности файла
            var fileEntity = new FileEntity()
            {
                Id = Guid.NewGuid(),
                FileName = fileName,
                FilePath = filePath,
                ContentType = contentType,
                ParentId = parentId
            };
            await _filesRepository.AddAsync(fileEntity);
        }

        public async Task<(byte[] fileContent, string ContentType, string FileName)> DownloadFile(Guid id)
        {
            var file = await _filesRepository.GetByIdAsync(id);
            if (file == null)
                throw new FileNotFoundException("File not found.");

            var fullPath = Path.Combine(_uploadFilePath, file.FilePath);
            var fileContent = await System.IO.File.ReadAllBytesAsync(fullPath);
            return (fileContent, file.ContentType, file.FileName);
        }

        public async Task DeleteFile(Guid id)
        {
            var file = await _filesRepository.GetByIdAsync(id);
            if (file == null)
                throw new FileNotFoundException("File not found.");

            var fullPath = Path.Combine(_uploadFilePath, file.FilePath);
            await _filesRepository.DeleteByIdAsync(id);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }

        public async Task<IReadOnlyList<FileEntity?>> GetAllFiles(Guid parentId)
        {
            return await _filesRepository.GetAllById(parentId);
        }
    }
}