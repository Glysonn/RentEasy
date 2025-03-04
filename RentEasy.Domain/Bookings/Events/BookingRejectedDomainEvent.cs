using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Bookings.Events;

public sealed record BookingRejectedDomainEvent(Guid Id) 
    : IDomainEvent;
