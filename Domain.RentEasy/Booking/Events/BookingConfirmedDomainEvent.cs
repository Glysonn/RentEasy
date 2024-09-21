using Domain.RentEasy.Abstractions;

namespace Domain.RentEasy.Booking.Events;

public record BookingConfirmedDomainEvent(Guid Id) : IDomainEvent;
