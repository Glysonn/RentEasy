using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Booking.Events;

public record BookingCompletedDomainEvent(Guid id) : IDomainEvent;
