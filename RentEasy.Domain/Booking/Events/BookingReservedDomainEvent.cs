using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Booking.Events;

public record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
