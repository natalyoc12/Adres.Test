using Adres.Procurement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adres.Procurement.Infrastructure.Persistence.Configurations;

public class ProcurementFileConfiguration : IEntityTypeConfiguration<ProcurementFileEntity>
{
    public void Configure(EntityTypeBuilder<ProcurementFileEntity> builder)
    {
        builder.ToTable("ProcurementFiles");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.FileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.FilePath)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.ContentType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Ignore(x => x.Content);

        builder.Property(x => x.Size)
            .IsRequired();

        builder.HasOne(f => f.Procurement)
            .WithMany(p => p.Files)
            .HasForeignKey(f => f.ProcurementId);
    }
}
