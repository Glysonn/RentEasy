using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RentEasy.Application.Abstractions.Behaviors;
using RentEasy.Domain.Booking;

namespace RentEasy.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var currentAssembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(currentAssembly);

            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(currentAssembly);
        services.AddTransient<PricingService>();

        return services;
    }
}
