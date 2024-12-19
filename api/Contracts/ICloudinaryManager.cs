using CloudinaryDotNet.Actions;

namespace Contracts;

public interface ICloudinaryManager
{
    IImageUploader ImageUploader { get; }
    IRawUploader RawUploader { get; }
    Task<DeletionResult> DeleteFile(string publicId);
}