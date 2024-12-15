using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Contracts;
using Microsoft.AspNetCore.Http;

namespace CloudinaryService;



public class ImageUploader : IImageUploader
{
    private readonly Cloudinary _cloudinary;

    public ImageUploader()
    {
        var acc = new Account(
            "dertrvymu",
            Environment.GetEnvironmentVariable("APIKEY"),
            Environment.GetEnvironmentVariable("APISECRET")
        );
        _cloudinary = new Cloudinary(acc);
    }



    public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
    {
        var uploadResult = new ImageUploadResult();

        if (file.Length <= 0) return uploadResult;
        await using var stream = file.OpenReadStream();
        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, stream)

        };

        uploadResult = await _cloudinary.UploadAsync(uploadParams);

        return uploadResult;
    }
    
    public async Task<DeletionResult> DeletePhotoAsync(string publicId)
    {
        var deleteParams = new DeletionParams(publicId);
        var result = await _cloudinary.DestroyAsync(deleteParams);

        return result;
    }
}
