using Shared.DataTransferObjects.AddressDtos;

namespace Shared.DataTransferObjects.EmployerDtos;

public class EmployerDto
{
    public Guid? UserId { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
    public string? Industry { get; set; }
    public DateOnly? Founded { get; set; }
    public string? Phone { get; set; }
    public string? SecondaryPhone { get; set; }
}