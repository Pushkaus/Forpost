namespace Forpost.Business.FileStorage;

public class DownloadFileCommand
{
    public byte[] FileContent { get; set; } = default!;
    public string ContentType { get; set; } = default!;
    public string FileName { get; set; } = default!;
}