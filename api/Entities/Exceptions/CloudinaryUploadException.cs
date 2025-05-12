namespace Entities.Exceptions;

public sealed class CloudinaryUploadException : BadRequestException
{
    public CloudinaryUploadException() : base("Error uploading the file to the cloudinary servers")
    {}

}