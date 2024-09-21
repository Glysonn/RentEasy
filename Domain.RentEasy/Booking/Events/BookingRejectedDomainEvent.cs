using Domain.RentEasy.Abstractions;

namespace Domain.RentEasy.Booking.Events;

public record BookingRejectedDomainEvent(Guid Id) : IDomainEvent;
