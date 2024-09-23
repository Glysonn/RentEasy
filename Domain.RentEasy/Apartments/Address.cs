namespace Domain.RentEasy.Apartments;

public record Address(
    string Country,
    string State,
    string ZipCode,
    string City,
    string Street);