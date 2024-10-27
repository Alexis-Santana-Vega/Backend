namespace CE.Chepeat.Domain.Interfaces.Services;
public interface IImageServicePresenter
{
    Task<string> UploadImageAsync(Stream imageStream, string fileName);
    Task<Stream> DownloadImageAsync(string fileName);
    Task DeleteImageAsync(string fileName);
}
