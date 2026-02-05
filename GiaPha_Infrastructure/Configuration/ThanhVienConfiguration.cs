using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiaPha_Infrastructure.Configuration;

public class ThanhVienConfiguration : IEntityTypeConfiguration<ThanhVien>
{
    public void Configure(EntityTypeBuilder<ThanhVien> builder)
    {
        builder.ToTable("ThanhViens");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.HoTen)
        
            .HasMaxLength(255);

        builder.Property(x => x.GioiTinh)
          ;

        builder.Property(x => x.NgaySinh);

        builder.Property(x => x.NgayMat);

        builder.Property(x => x.NoiSinh)
            .HasMaxLength(500);

        builder.Property(x => x.TieuSu)
            .HasMaxLength(2000);

        builder.Property(x => x.TrangThai)
       
            .HasDefaultValue(1);

        builder.Property(x => x.HoId)
            ;

        builder.Property(x => x.ChiHoId);

     

        // Relationships
        builder.HasOne(x => x.Ho)
            .WithMany(h => h.ThanhViens)
            .HasForeignKey(x => x.HoId)
            .OnDelete(DeleteBehavior.Restrict);

        // ChiHo relationship đã được định nghĩa ở ChiHoConfiguration

      
        // Indexes
        builder.HasIndex(x => x.HoId);
        builder.HasIndex(x => x.ChiHoId);

    }
}
