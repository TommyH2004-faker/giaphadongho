
using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GiaPha_Infrastructure.Configuration;
public class SuKienConfiguration : IEntityTypeConfiguration<SuKien>
{
    public void Configure(EntityTypeBuilder<SuKien> builder)
    {
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id)
             .HasDefaultValueSql("(UUID())")
             .ValueGeneratedOnAdd();
        builder.Property(x => x.LoaiSuKien).IsRequired().HasMaxLength(100);
        builder.HasOne(x => x.ThanhVien)
               .WithMany()
               .HasForeignKey(x => x.ThanhVienId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}   