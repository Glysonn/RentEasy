using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Bookings.Events;

public record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
