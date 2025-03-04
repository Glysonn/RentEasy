using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Bookings.Events;

public sealed record BookingReservedDomainEvent(Guid BookingId) 
    : IDomainEvent;
