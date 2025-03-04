using RentEasy.Domain.Abstractions;

namespace RentEasy.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) 
    : IDomainEvent;
