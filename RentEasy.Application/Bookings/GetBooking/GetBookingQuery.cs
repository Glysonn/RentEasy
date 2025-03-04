using RentEasy.Application.Abstractions.Messaging;

namespace RentEasy.Application.Bookings.GetBooking;

public sealed record GetBookingQuery(Guid BookingId) 
    : IQuery<BookingResponse>;