using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Booking.Events;

public record BookingRejectedDomainEvent(Guid Id) : IDomainEvent;
