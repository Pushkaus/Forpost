namespace Forpost.Business.FileStorage;

public class UploadFileCommand
{
    public string FileName { get; set; } = default!;
    public byte[] Content { get; set; } = default!;
    public string ContentType { get; set; } = default!;
    public Guid ParentId { get; set; } 
}