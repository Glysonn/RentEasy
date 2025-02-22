using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Bookings.Events;

public record BookingRejectedDomainEvent(Guid Id) : IDomainEvent;
