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
        // cot gioi tinh chỉ nhận số để dùng enums
        builder.Property(x => x.GioiTinh).HasConversion<int>();
        builder.Property(x => x.ActivationCode).HasMaxLength(100);
        builder.Property(x => x.Enabled).HasDefaultValue(false);
        builder.Property(x => x.RefreshToken).HasMaxLength(500);
        builder.Property(x=>x.RefreshTokenExpiry);
        
        // Relationship với ThanhVien (1-1)
        builder.HasOne(x => x.ThanhVien)
            .WithOne()
            .HasForeignKey<TaiKhoanNguoiDung>(x => x.ThanhVienId)
            .OnDelete(DeleteBehavior.SetNull);
            
        // Relationship với ChiHo (N-1)
        builder.HasOne(x => x.ChiHo)
            .WithMany()
            .HasForeignKey(x => x.ChiHoId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
