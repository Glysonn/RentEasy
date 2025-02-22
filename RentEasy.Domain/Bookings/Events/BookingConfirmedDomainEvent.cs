using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Bookings.Events;

public record BookingConfirmedDomainEvent(Guid Id) : IDomainEvent;
