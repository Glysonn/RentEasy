using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Bookings.Events;

public sealed record BookingCompletedDomainEvent(Guid Id) 
    : IDomainEvent;
