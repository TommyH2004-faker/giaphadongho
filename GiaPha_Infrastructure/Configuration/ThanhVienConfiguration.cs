using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiaPha_Infrastructure.Configuration;

public class ThanhVienConfiguration : IEntityTypeConfiguration<ThanhVien>
{
    public void Configure(EntityTypeBuilder<ThanhVien> builder)
    {
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id)
             .HasDefaultValueSql("(UUID())")
             .ValueGeneratedOnAdd();
        builder.Property(x => x.HoTen).IsRequired().HasMaxLength(255);
        builder.Property(x => x.GioiTinh).IsRequired().HasMaxLength(10);
        builder.HasOne(x => x.ChiHo)
               .WithMany(x => x.ThanhViens)
               .HasForeignKey(x => x.ChiHoId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
