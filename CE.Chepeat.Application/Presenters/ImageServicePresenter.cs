namespace CE.Chepeat.Application.Presenters;
public class ImageServicePresenter : IImageServicePresenter
{
    private readonly IUnitRepository _unitRepository;

    public ImageServicePresenter(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public async Task<string> UploadImageAsync(Stream imageStream, string fileName)
    {
        return await _unitRepository.imageServiceInfraestructure.UploadImageAsync(imageStream, fileName);
    }

    public async Task<Stream> DownloadImageAsync(string fileName)
    {
        return await _unitRepository.imageServiceInfraestructure.DownloadImageAsync(fileName);
    }

    public async Task DeleteImageAsync(string fileName)
    {
        await _unitRepository.imageServiceInfraestructure.DeleteImageAsync(fileName);
    }
}
