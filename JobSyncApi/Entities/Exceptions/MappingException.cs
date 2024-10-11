namespace Entities.Exceptions;

public class MappingException : BadRequestException
{
    public MappingException(string model) : base($"Coulnd't map the {model} model to the dto "){}
}