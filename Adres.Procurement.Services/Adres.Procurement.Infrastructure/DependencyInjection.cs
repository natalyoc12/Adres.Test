using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Adres.Procurement.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Adres.Procurement.Infrastructure.Persistence;
using Adres.Procurement.Infrastructure.Persistence.Repositories;

namespace Adres.Procurement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {
        string? connectionString = config.GetConnectionString("DefaultConnection")
            ?? Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IProcurementRepository, ProcurementRepository>();
        services.AddScoped<IProcurementFileRepository, ProcurementFileRepository>();

        return services;
    }
}
