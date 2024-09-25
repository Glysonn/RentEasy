using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Booking.Events;

public record BookingConfirmedDomainEvent(Guid Id) : IDomainEvent;
