using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Bookings.Events;

public sealed record BookingConfirmedDomainEvent(Guid Id) 
    : IDomainEvent;
