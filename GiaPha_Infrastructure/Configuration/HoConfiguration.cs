using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiaPha_Infrastructure.Configuration;

public class HoConfiguration : IEntityTypeConfiguration<Ho>
{
    public void Configure(EntityTypeBuilder<Ho> builder)
    {
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id)
             .HasDefaultValueSql("(UUID())")
             .ValueGeneratedOnAdd();
        builder.Property(x => x.TenHo).IsRequired().HasMaxLength(255);
        builder.HasMany(x => x.CacChiHo)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);
    }
}
