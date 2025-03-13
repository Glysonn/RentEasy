using RentEasy.Application.Abstractions.Authentication;
using RentEasy.Domain.Users;
using RentEasy.Infrastructure.Authentication.Models;
using System.Net.Http.Json;

namespace RentEasy.Infrastructure.Authentication;

internal sealed class AuthenticationService(
    HttpClient httpClient) 
    : IAuthenticationService
{
    private const string PasswordCredentialType = "password";
    
    private readonly HttpClient _httpClient = httpClient;

    public async Task<string> RegisterAsync(
        User user,
        string password,
        CancellationToken cancellationToken = default)
    {
        var userRepresentationmodel = UserRepresentationModel.FromUser(user);

        userRepresentationmodel.Credentials =
        [
            new()
            {
                Value = password,
                Temporary = false,
                Type = PasswordCredentialType
            }
        ];

        var response = await _httpClient.PostAsJsonAsync(
            "users",
            userRepresentationmodel,
            cancellationToken);

        return ExtractIdentityIdFromLocationHeader(response);
    }

    private static string ExtractIdentityIdFromLocationHeader(
        HttpResponseMessage httpResponseMessage)
    {
        const string usersSegmentName = "users/";

        var locationHeader = (httpResponseMessage.Headers.Location?.PathAndQuery) 
            ?? throw new InvalidOperationException("Location header can`t be null");

        var userSegmentValueIndex = locationHeader.IndexOf(
            usersSegmentName,
            StringComparison.InvariantCultureIgnoreCase);

        var userIdentityId = locationHeader[(userSegmentValueIndex + usersSegmentName.Length)..];

        return userIdentityId;
    }
}
