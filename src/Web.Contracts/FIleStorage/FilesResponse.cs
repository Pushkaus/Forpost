namespace Forpost.Web.Contracts.FIleStorage;

public class FilesResponse
{
    public Guid Id { get; set; }
    public Guid ParentId { get; set; }
    public byte[] FileContent { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
}