namespace Entities.Exceptions.JobExceptions;

public class JobNotFoundException : NotFoundException
{
    public JobNotFoundException(Guid id) : base($"Job with id: {id} not found ")
    {
    }
}