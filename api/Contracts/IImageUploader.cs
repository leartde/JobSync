using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Contracts;

public interface IImageUploader
{
    Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
}