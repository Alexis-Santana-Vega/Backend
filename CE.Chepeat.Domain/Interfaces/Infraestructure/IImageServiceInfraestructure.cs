using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.Interfaces.Infraestructure;
public interface IImageServiceInfraestructure
{
    Task<string> UploadImageAsync(Stream imageStream, string fileName);
    Task<Stream> DownloadImageAsync(string fileName);
    Task DeleteImageAsync(string fileName);
}
