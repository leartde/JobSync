using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Contracts;

public interface IPdfUploader
{
    Task<UploadResult> AddPdfAsync(IFormFile file);
}