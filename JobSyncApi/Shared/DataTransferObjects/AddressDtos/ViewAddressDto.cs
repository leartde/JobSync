using Entities.Exceptions;
using Entities.Models;

namespace Shared.DataTransferObjects.AddressDtos;

public  class ViewAddressDto  : AddressDto
{
    public Guid Id { get; set; }
    
};
