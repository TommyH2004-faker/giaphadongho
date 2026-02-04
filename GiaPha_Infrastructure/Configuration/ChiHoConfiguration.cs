using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiaPha_Infrastructure.Configuration;

public class ChiHoConfiguration : IEntityTypeConfiguration<ChiHo>
{
    public void Configure(EntityTypeBuilder<ChiHo> builder)
    {
        builder.ToTable("ChiHos");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.TenChiHo)
            .HasMaxLength(255);

        builder.Property(x => x.MoTa)
            .HasMaxLength(1000);

        builder.Property(x => x.HoId);

        builder.Property(x => x.TruongChiId);

        // Relationships
        builder.HasOne(x => x.Ho)
            .WithMany(x => x.ChiHos)
            .HasForeignKey(x => x.HoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.TruongChi)
            .WithMany()
            .HasForeignKey(x => x.TruongChiId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ThanhViens)
            .WithOne(x => x.ChiHo)
            .HasForeignKey(x => x.ChiHoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(x => x.HoId);
        builder.HasIndex(x => x.TruongChiId);
    }
}
