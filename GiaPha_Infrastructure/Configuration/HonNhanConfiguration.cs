using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiaPha_Infrastructure.Configuration;

public class HonNhanConfiguration : IEntityTypeConfiguration<HonNhan>
{
    public void Configure(EntityTypeBuilder<HonNhan> builder)
    {
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id)
             .HasDefaultValueSql("(UUID())")
             .ValueGeneratedOnAdd();
        builder.HasOne(x => x.Chong)
               .WithMany()
               .HasForeignKey(x => x.ChongId)
               .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Vo)
               .WithMany()
               .HasForeignKey(x => x.VoId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
