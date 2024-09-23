﻿using Domain.RentEasy.Abstractions;

namespace Domain.RentEasy.Booking.Events;

public record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
