using RentEasy.Application.Abstractions.Authentication;
using RentEasy.Application.Abstractions.Messaging;
using RentEasy.Domain.Abstractions;
using RentEasy.Domain.Users;

namespace RentEasy.Application.Users.LogInUser;

internal sealed class LogInUserCommandHandler(IJwtService jwtService) 
    : ICommandHandler<LogInUserCommand, AccessTokenResponse>
{
    private readonly IJwtService _jwtService = jwtService;

    public async Task<Result<AccessTokenResponse>> Handle(
        LogInUserCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await _jwtService.GetAccessTokenAsync(
            request.Email,
            request.Password,
            cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<AccessTokenResponse>(UserErrors.InvalidCredentials);
        }

        return new AccessTokenResponse(result.Value);
    }
}
