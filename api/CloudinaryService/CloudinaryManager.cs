using CloudinaryDotNet;
using Contracts;

namespace CloudinaryService;

public class CloudinaryManager : ICloudinaryManager
{
    private readonly Cloudinary _cloudinary;
    private readonly Lazy<IImageUploader> _imageUploader;
    private readonly Lazy<IRawUploader> _rawUploader;

    public CloudinaryManager()
    {
        Account acc = new Account(
            "dertrvymu",
            Environment.GetEnvironmentVariable("APIKEY"),
            Environment.GetEnvironmentVariable("APISECRET")
        );
        _cloudinary = new Cloudinary(acc);
        _imageUploader = new Lazy<IImageUploader>(() => new
            ImageUploader(_cloudinary)
        );
        _rawUploader = new Lazy<IRawUploader>(() => new
            RawUploader(_cloudinary)
        );
    }

    public IImageUploader ImageUploader => _imageUploader.Value;
    public IRawUploader RawUploader => _rawUploader.Value;


}