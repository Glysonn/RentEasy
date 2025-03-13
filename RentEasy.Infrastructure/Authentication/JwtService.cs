using Microsoft.Extensions.Options;
using RentEasy.Application.Abstractions.Authentication;
using RentEasy.Domain.Abstractions;
using RentEasy.Infrastructure.Authentication.Models;
using System.Net.Http.Json;

namespace RentEasy.Infrastructure.Authentication;

internal sealed class JwtService(
    HttpClient httpClient,
    IOptions<KeycloakOptions> keycloakOptions)
    : IJwtService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly KeycloakOptions _keycloakOptions = keycloakOptions.Value;

    private static readonly Error AuthenticationFailed = new(
        "Keycloak.AuthenticationFailed",
        "Failed to acquire access token do to authentication failure");

    public async Task<Result<string>> GetAccessTokenAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var authRequestParameters = new KeyValuePair<string, string>[]
            {
                new("client_id", _keycloakOptions.AuthClientId),
                new("client_secret", _keycloakOptions.AuthClientSecret),
                new("scope", "openid email"),
                new("grant_type", "password"),
                new("username", email),
                new("password", password)
            };

            var authorizationRequestContent = new FormUrlEncodedContent(authRequestParameters);

            var response = await _httpClient.PostAsync("", authorizationRequestContent, cancellationToken);

            response.EnsureSuccessStatusCode();

            var authorizationToken = await response.Content.ReadFromJsonAsync<AuthorizationToken>();

            if (authorizationToken is null)
            {
                return Result.Failure<string>(AuthenticationFailed);
            }

            return authorizationToken.AccessToken;
        }
        catch (HttpRequestException)
        {
            return Result.Failure<string>(AuthenticationFailed);
        }
    }
}
