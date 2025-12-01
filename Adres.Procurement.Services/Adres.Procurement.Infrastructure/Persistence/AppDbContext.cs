using Microsoft.EntityFrameworkCore;
using Adres.Procurement.Domain.Entities;

namespace Adres.Procurement.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ProcurementEntity> Procurements { get; set; }
    public DbSet<ProcurementFileEntity> ProcurementFiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
