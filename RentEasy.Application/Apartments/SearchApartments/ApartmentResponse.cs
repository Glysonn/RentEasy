using RentEasy.Domain.Apartments;
using RentEasy.Domain.Shared;

namespace RentEasy.Application.Apartments.SearchApartments;

public sealed record ApartmentResponse
{
    public string Name { get; init; }

    public string Description { get; init; }
    public decimal Price { get; init; }
    public string Currency { get; init; }
    public AddressResponse Address { get; set; }
}
