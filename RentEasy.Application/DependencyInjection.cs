using Microsoft.Extensions.DependencyInjection;
using RentEasy.Application.Abstractions.Behaviors;
using RentEasy.Domain.Booking;

namespace RentEasy.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddTransient<PricingService>();

        return services;
    }
}
