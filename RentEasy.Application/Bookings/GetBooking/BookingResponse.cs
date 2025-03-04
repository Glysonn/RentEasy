namespace RentEasy.Application.Bookings.GetBooking;

public sealed record BookingResponse(
    Guid Id,
    Guid UserId,
    Guid ApartmentId,
    int Status,
    decimal PriceAmount,
    string PriceCurrency,
    decimal CleaningFeeAmount,
    string CleaningFeeCurrency,
    decimal AmenitiesUpChargeAmount,
    string AmenitiesUpChargeCurrency,
    decimal TotalPriceAmount,
    DateOnly DurationStart,
    DateOnly DurationEnd,
    DateOnly CreatedOnUtc
);
