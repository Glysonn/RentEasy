using RentEasy.Domain.Shared;

namespace RentEasy.Domain.Booking;

public record PricingDetails(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice);
