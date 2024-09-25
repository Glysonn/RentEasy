using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Users.Events;

public record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
