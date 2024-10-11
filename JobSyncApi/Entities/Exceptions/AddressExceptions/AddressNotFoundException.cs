namespace Entities.Exceptions.AddressExceptions;

public sealed class AddressNotFoundException : NotFoundException
{
    public AddressNotFoundException(Guid addressId)
        : base($"Address with id {addressId} doesn't exist."){}
}