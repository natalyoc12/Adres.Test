using Adres.Procurement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adres.Procurement.Infrastructure.Persistence.Configurations;

public class ProcurementConfiguration : IEntityTypeConfiguration<ProcurementEntity>
{
    public void Configure(EntityTypeBuilder<ProcurementEntity> builder)
    {
        builder.ToTable("Procurements");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Budget)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Entity)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Item)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.Quantity)
            .HasColumnType("float")
            .IsRequired();

        builder.Property(x => x.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.TotalPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Date)
            .IsRequired();

        builder.Property(x => x.Supplier)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired();

        builder.HasMany(p => p.Files)
           .WithOne(f => f.Procurement)
           .HasForeignKey(f => f.ProcurementId)
           .OnDelete(DeleteBehavior.Cascade);
    }
}
