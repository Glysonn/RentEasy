using Microsoft.EntityFrameworkCore;
using RentEasy.Infrastructure;

namespace RentEasy.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        using var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        dbContext.Database.Migrate();
    }
}