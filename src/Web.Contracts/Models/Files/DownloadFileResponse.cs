namespace Forpost.Web.Contracts.Models.Files;

public class DownloadFileResponse
{
    public byte[] FileContent { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
}