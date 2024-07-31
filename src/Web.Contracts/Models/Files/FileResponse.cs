namespace Forpost.Web.Contracts.Models.Files;

public class FileResponse
{
    public Guid Id { get; set; }
    public Guid ParentId { get; set; }
    public byte[] FileContent { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
}