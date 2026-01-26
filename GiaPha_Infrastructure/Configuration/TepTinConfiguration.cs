using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiaPha_Infrastructure.Configuration;

public class TepTinConfiguration : IEntityTypeConfiguration<TepTin>
{
    public void Configure(EntityTypeBuilder<TepTin> builder)
    {
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id)
             .HasDefaultValueSql("(UUID())")
             .ValueGeneratedOnAdd();
        builder.Property(x => x.DuongDan).IsRequired();
        builder.Property(x => x.LoaiTep).IsRequired().HasMaxLength(50);
    }
}
