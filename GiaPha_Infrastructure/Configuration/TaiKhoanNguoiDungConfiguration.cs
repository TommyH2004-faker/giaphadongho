using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiaPha_Infrastructure.Configuration;

public class TaiKhoanNguoiDungConfiguration : IEntityTypeConfiguration<TaiKhoanNguoiDung>
{
    public void Configure(EntityTypeBuilder<TaiKhoanNguoiDung> builder)
    {
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id)
             .HasDefaultValueSql("(UUID())")
             .ValueGeneratedOnAdd();
        builder.Property(x => x.TenDangNhap).IsRequired().HasMaxLength(100);
        builder.Property(x => x.MatKhauMaHoa).IsRequired();
        builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Role).IsRequired().HasMaxLength(50);
    }
}
