namespace Forpost.Business.Models.Files;

public class FileAddModel
{
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public string ContentType { get; set; }
    public Guid ParentId { get; set; }
}