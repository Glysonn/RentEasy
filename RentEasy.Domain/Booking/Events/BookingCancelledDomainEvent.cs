using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Booking.Events;

public record BookingCancelledDomainEvent(Guid Id) : IDomainEvent;
