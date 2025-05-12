using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Contracts;

public interface IRawUploader
{
    Task<RawUploadResult> AddFileAsync(IFormFile file);
}