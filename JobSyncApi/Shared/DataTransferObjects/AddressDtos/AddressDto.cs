namespace Shared.DataTransferObjects.AddressDtos;

public  class AddressDto
{
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? State { get; set; }
    public string? Region { get; set; }
    public string Street { get; set; } = string.Empty;
    public int ZipCode { get; set; }

    // public AddressDto(string c, string ci, string s, string r, string st, int z)
    // {
    //     Country = c;
    //     City = ci;
    //     State = s;
    //     Region = r;
    //     Street = st;
    //     ZipCode = z;
    // }
    
}