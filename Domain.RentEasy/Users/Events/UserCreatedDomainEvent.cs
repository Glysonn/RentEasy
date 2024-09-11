using Domain.RentEasy.Abstractions;

namespace Domain.RentEasy.Users.Events;

public record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
