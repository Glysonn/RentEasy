namespace RentEasy.Application.Apartments.SearchApartments;

public sealed record ApartmentResponse(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    string Currency,
    AddressResponse Address
);
