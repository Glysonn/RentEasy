using Domain.RentEasy.Shared;

namespace Domain.RentEasy.Booking;

public record PricingDetails(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice);
