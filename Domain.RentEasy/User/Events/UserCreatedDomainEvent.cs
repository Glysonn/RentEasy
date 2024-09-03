using Domain.RentEasy.Abstractions;

namespace Domain.RentEasy.User.Events;

public record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
