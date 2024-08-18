namespace Forpost.Business.Models.Files;

public class DownloadFileModel
{
    public byte[] FileContent { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
}