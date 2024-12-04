namespace Entities.Exceptions;

public class NullAttributeException : BadRequestException
{
    public NullAttributeException(string attribute) : base($"{attribute} cannot be null")
    {
    }
}