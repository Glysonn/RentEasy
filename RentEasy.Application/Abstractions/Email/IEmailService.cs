namespace RentEasy.Application.Abstractions.Email;

internal interface IEmailService
{
    Task SendAsync(Domain.Users.Email recipient, string subject, string body);
}
