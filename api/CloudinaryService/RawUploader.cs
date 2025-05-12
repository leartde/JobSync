using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Contracts;
using Entities.Exceptions;
using Microsoft.AspNetCore.Http;

namespace CloudinaryService;

internal sealed class RawUploader : IRawUploader
{
    private readonly Cloudinary _cloudinary;
    public RawUploader(Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }

    public async Task<RawUploadResult> AddFileAsync(IFormFile file)
    {
        RawUploadResult uploadResult = new RawUploadResult();

        if (file.Length <= 0) return uploadResult;

        await using Stream stream = file.OpenReadStream();
        RawUploadParams uploadParams = new RawUploadParams
        {
            File = new FileDescription(file.FileName, stream)
        };

        uploadResult = await _cloudinary.UploadAsync(uploadParams);
        return uploadResult;
    }

}