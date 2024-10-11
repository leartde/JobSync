﻿namespace Shared.DataTransferObjects;

public class AddAddressDto
{
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? State { get; set; }
    public string? Region { get; set; }
    public string Street { get; set; } = string.Empty;
    public int ZipCode { get; set; } 
}