namespace RentEasy.Application.Apartments.SearchApartments;

public sealed record AddressResponse(
    string Country,
    string State,
    string ZipCode,
    string City,
    string Street
);
