using RentEasy.Application.Abstractions.Messaging;

namespace RentEasy.Application.Users.LogInUser;

public sealed record LogInUserCommand(string Email, string Password)
    : ICommand<AccessTokenResponse>;
