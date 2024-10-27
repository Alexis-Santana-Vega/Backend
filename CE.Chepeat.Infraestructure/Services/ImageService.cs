using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CE.Chepeat.Infraestructure.Services;
public class ImageService : IImageServiceInfraestructure
{
    private readonly string _bucketName = "gs://chepeat-c9a5c.appspot.com";  // Cambia por tu bucket de Firebase
    private readonly StorageClient _storageClient;
    private readonly IConfiguration _configuration;

    public ImageService(IConfiguration configuration)
    {
        _configuration = configuration;
        // Obtener el JSON de las credenciales desde appsettings.json
        string credentialsJson = configuration["Firebase:CredentialsJson"];

        GoogleCredential credential = GoogleCredential.FromJson(credentialsJson);

        // Configurar Firebase con las credenciales
        if (FirebaseApp.DefaultInstance == null)
        {
            FirebaseApp.Create(new AppOptions
            {
                Credential = credential
            });
        }

        _storageClient = StorageClient.Create(credential);
    }

    public async Task<string> UploadImageAsync(Stream imageStream, string fileName)
    {
        var imageObject = await _storageClient.UploadObjectAsync(
            bucket: _bucketName,
            objectName: $"images/{fileName}",
            contentType: "image/jpeg",  // Cambia según el tipo de archivo
            source: imageStream
        );

        return $"https://storage.googleapis.com/{_bucketName}/{imageObject.Name}";
    }

    public async Task<Stream> DownloadImageAsync(string fileName)
    {
        MemoryStream memoryStream = new MemoryStream();
        await _storageClient.DownloadObjectAsync(
            bucket: _bucketName,
            objectName: $"images/{fileName}",
            destination: memoryStream
        );

        memoryStream.Position = 0; // Reinicia el stream para su lectura
        return memoryStream;
    }

    public async Task DeleteImageAsync(string fileName)
    {
        await _storageClient.DeleteObjectAsync(
            bucket: _bucketName,
            objectName: $"images/{fileName}"
        );
    }

}
