using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Contracts;

public interface IRawUploader
{
    Task<UploadResult> AddPdfAsync(IFormFile file);
}