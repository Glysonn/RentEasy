using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Apartments;

public static class ApartmentErrors
{
    public static readonly Error NotFound = new(
        "Apartment.NotFound",
        "The apartment with the specified identifier was not found");
}
