using Shared.DataTransferObjects.AddressDtos;

namespace Shared.DataTransferObjects.EmployerDtos;

public abstract class EmployerDto
{
    public Guid? UserId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public string? Headquarters { get; set; }
    public string? Website { get; set; }
    public string? Industry { get; set; }
    public DateOnly? Founded { get; set; }
    public string? Phone { get; set; }
    public string? SecondaryPhone { get; set; }
}