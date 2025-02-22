using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;
