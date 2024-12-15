namespace Contracts;

public interface ICloudinaryManager
{
    IImageUploader ImageUploader { get; }
    IRawUploader RawUploader { get; }
}