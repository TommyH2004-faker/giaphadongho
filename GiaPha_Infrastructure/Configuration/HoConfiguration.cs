using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiaPha_Infrastructure.Configuration;

public class HoConfiguration : IEntityTypeConfiguration<Ho>
{
    public void Configure(EntityTypeBuilder<Ho> builder)
    {
        builder.ToTable("Hos");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.TenHo)
 
            .HasMaxLength(255);

        builder.Property(x => x.MoTa)
            .HasMaxLength(1000);

        builder.Property(x => x.HinhAnh)
            .HasMaxLength(500);

        builder.Property(x => x.NgayTao);

        builder.Property(x => x.QueQuan)
            .HasMaxLength(500);

        builder.Property(x => x.ThuyToId);

        // Relationships
        builder.HasOne(x => x.ThuyTo)
            .WithMany()
            .HasForeignKey(x => x.ThuyToId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ChiHos)
            .WithOne(x => x.Ho)
            .HasForeignKey(x => x.HoId)
            .OnDelete(DeleteBehavior.Cascade);

      

        // Indexes
        builder.HasIndex(x => x.ThuyToId);
    }
}
