using Microsoft.AspNetCore.Http;

namespace Forpost.Web.Contracts.FIleStorage;

public class UploadFileRequest
{
    public Guid ParentId { get; set; }
    public IFormFile File { get; set; } 
}