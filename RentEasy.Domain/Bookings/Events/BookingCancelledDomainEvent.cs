using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Bookings.Events;

public record BookingCancelledDomainEvent(Guid Id) : IDomainEvent;
