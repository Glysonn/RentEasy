﻿using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentEasy.Application.Abstractions.Clock;
using RentEasy.Application.Abstractions.Data;
using RentEasy.Application.Abstractions.Email;
using RentEasy.Domain.Abstractions;
using RentEasy.Domain.Apartments;
using RentEasy.Domain.Bookings;
using RentEasy.Domain.Reviews;
using RentEasy.Domain.Users;
using RentEasy.Infrastructure.Clock;
using RentEasy.Infrastructure.Data;
using RentEasy.Infrastructure.Data.TypeHandlers;
using RentEasy.Infrastructure.Email;
using RentEasy.Infrastructure.Repositories;

namespace RentEasy.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();

        var connectionString = configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IApartmentRepository, ApartmentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

        return services;
    }
}
