namespace Forpost.Web.Contracts.FIleStorage;

public class DownloadFileResponse
{
    public byte[] FileContent { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
}