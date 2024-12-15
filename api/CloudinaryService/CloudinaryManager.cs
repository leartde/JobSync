using CloudinaryDotNet;
using Contracts;

namespace CloudinaryService;

public class CloudinaryManager : ICloudinaryManager
{
    private readonly Lazy<IImageUploader> _imageUploader;
    private readonly Lazy<IRawUploader> _rawUploader;

    public CloudinaryManager()
    {
        Account acc = new Account(
            "dertrvymu",
            Environment.GetEnvironmentVariable("APIKEY"),
            Environment.GetEnvironmentVariable("APISECRET")
        );
        Cloudinary cloudinary = new Cloudinary(acc);
        _imageUploader = new Lazy<IImageUploader>(() => new
            ImageUploader(cloudinary)
        );
        _rawUploader = new Lazy<IRawUploader>(() => new
            RawUploader(cloudinary)
        );
    }

    public IImageUploader ImageUploader => _imageUploader.Value;
    public IRawUploader RawUploader => _rawUploader.Value;


}