using Domain.RentEasy.Abstractions;

namespace Domain.RentEasy.Booking.Events;

public record BookingCancelledDomainEvent(Guid Id) : IDomainEvent;
