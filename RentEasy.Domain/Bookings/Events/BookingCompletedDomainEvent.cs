using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Bookings.Events;

public record BookingCompletedDomainEvent(Guid id) : IDomainEvent;
