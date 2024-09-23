using Domain.RentEasy.Abstractions;

namespace Domain.RentEasy.Booking.Events;

public record BookingCompletedDomainEvent(Guid id) : IDomainEvent;
