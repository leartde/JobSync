namespace Entities.Exceptions.EmployerExceptions;

public class EmployerNotFoundException : NotFoundException
{
    public EmployerNotFoundException(Guid addressId)
        : base($"Employer with id {addressId} doesn't exist."){}
}