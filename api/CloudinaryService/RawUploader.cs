using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Contracts;
using Microsoft.AspNetCore.Http;

namespace CloudinaryService;

internal sealed class RawUploader : IRawUploader
{
    private readonly Cloudinary _cloudinary;
    public RawUploader(Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }

    public async Task<UploadResult> AddFileAsync(IFormFile file)
    {
        RawUploadResult uploadResult = new RawUploadResult();
        if (file.Length <= 0) return uploadResult;
        await using Stream stream = file.OpenReadStream();
        using MemoryStream memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);
        memoryStream.Position = 0;
        RawUploadParams uploadParams = new RawUploadParams
        {
            File = new FileDescription(file.FileName, memoryStream),
        };
        uploadResult = await _cloudinary.UploadAsync(uploadParams);
        Console.WriteLine($"Upload Result: {uploadResult.StatusCode}, Error: {uploadResult.Error?.Message}");

        return uploadResult;
    }
}