using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentEasy.Application.Abstractions.Clock;
using RentEasy.Application.Abstractions.Email;
using RentEasy.Infrastructure.Clock;
using RentEasy.Infrastructure.Email;

namespace RentEasy.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}
