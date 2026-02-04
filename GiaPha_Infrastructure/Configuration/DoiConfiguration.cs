using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiaPha_Infrastructure.Configuration;

public class DoiConfiguration : IEntityTypeConfiguration<Doi>
{
    public void Configure(EntityTypeBuilder<Doi> builder)
    {
        builder.ToTable("Dois");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.SoDoi);

        builder.Property(x => x.TenDoi)
            .HasMaxLength(255);

        builder.Property(x => x.HoId);

        // Relationships
        builder.HasOne(x => x.Ho)
            .WithMany()
            .HasForeignKey(x => x.HoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}