using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Adres.Procurement.Infrastructure.Persistence.Seed;

public static class DbInitializer
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await context.Database.MigrateAsync();

        if (await context.Procurements.AnyAsync())
        {
            return;
        }

        context.Procurements.AddRange(SeedData.Procurements);
        await context.SaveChangesAsync();
    }
}
