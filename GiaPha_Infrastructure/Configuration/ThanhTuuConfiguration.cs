using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiaPha_Infrastructure.Configuration;

public class ThanhTuuConfiguration : IEntityTypeConfiguration<ThanhTuu>
{
    public void Configure(EntityTypeBuilder<ThanhTuu> builder)
    {
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id)
             .HasDefaultValueSql("(UUID())")
             .ValueGeneratedOnAdd();
        builder.Property(x => x.TenThanhTuu).IsRequired().HasMaxLength(255);
        builder.HasOne(x => x.ThanhVien)
               .WithMany()
               .HasForeignKey(x => x.ThanhVienId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
