using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiaPha_Infrastructure.Configuration;

public class ChiHoConfiguration : IEntityTypeConfiguration<ChiHo>
{
    public void Configure(EntityTypeBuilder<ChiHo> builder)
    {
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id)
             .HasDefaultValueSql("(UUID())")
             .ValueGeneratedOnAdd();
        builder.Property(x => x.TenChiHo).IsRequired().HasMaxLength(255);
        builder.HasOne(x => x.TruongChi)
               .WithMany()
               .HasForeignKey(x => x.TruongChiId)
               .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.ThanhViens)
               .WithOne(x => x.ChiHo)
               .HasForeignKey(x => x.ChiHoId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
