using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiaPha_Infrastructure.Configuration;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id)
             .HasDefaultValueSql("(UUID())")
             .ValueGeneratedOnAdd();
        builder.Property(x => x.TenAlbum).IsRequired().HasMaxLength(255);
        builder.HasMany(x => x.TepTins)
               .WithOne()
               .HasForeignKey(x => x.ThanhVienId)
               .OnDelete(DeleteBehavior.SetNull);
         builder.Property(x => x.CreatedAt).IsRequired()
             .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
             .ValueGeneratedOnAdd();
        
    }
}
