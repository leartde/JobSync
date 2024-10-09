namespace Entities.Models;

public class Employer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Address? Address { get; set; }
    public Guid AddressId { get; set; }
    public string Industry { get; set; } = string.Empty;
    public DateOnly Founded { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string? SecondaryPhone { get; set; } = string.Empty;
    public List<Job>? Jobs { get; set; }



}