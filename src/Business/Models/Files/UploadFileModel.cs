namespace Forpost.Business.Models.Files;

public class UploadFileModel
{
    public string FileName { get; set; }
    public byte[] Content { get; set; }
    public string ContentType { get; set; }
    public Guid ParentId { get; set; }
}