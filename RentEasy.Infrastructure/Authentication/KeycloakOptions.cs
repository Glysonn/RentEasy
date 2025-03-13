namespace RentEasy.Infrastructure.Authentication;

public sealed class KeycloakOptions
{
    public string AdminUrl { get; set; } = string.Empty;

    public string TokenUrl { get; set; } = string.Empty;

    public string AdminClientId { get; set; } = string.Empty;

    public string AdminClientSecret { get; set; } = string.Empty;

    public string AuthClientId { get; set; } = string.Empty;

    public string AuthClientSecret { get; set; } = string.Empty;

}
