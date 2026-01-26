using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiaPha_Infrastructure.Configuration;

public class QuanHeChaConConfiguration : IEntityTypeConfiguration<QuanHeChaCon>
{
    public void Configure(EntityTypeBuilder<QuanHeChaCon> builder)
    {
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id)
             .HasDefaultValueSql("(UUID())")
             .ValueGeneratedOnAdd();
        builder.HasOne(x => x.ChaMe)
               .WithMany()
               .HasForeignKey(x => x.ChaMeId)
               .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Con)
               .WithMany()
               .HasForeignKey(x => x.ConId)
               .OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.LoaiQuanHe).IsRequired().HasMaxLength(50);
    }
}
