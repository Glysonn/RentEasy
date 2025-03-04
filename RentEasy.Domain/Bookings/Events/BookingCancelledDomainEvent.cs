using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Bookings.Events;

public sealed record BookingCancelledDomainEvent(Guid Id) 
    : IDomainEvent;
