namespace Shared.DataTransferObjects.EmployerDtos;

public class EmployerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Industry { get; set; } = string.Empty;
    public DateOnly Founded { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string? SecondaryPhone { get; set; } = string.Empty;
    public AddressDto? Address { get; set; }
}