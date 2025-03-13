using RentEasy.Application.Abstractions.Messaging;

namespace RentEasy.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
    string Email,
    string FirstName,
    string LastName,
    string Password) : ICommand<Guid>;
