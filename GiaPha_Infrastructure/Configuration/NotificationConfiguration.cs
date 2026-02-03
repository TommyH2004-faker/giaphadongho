using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiaPha_Infrastructure.Configuration;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id)
             .HasDefaultValueSql("(UUID())")
             .ValueGeneratedOnAdd();
        builder.Property(x => x.NoiDung).IsRequired();
        builder.Property(x => x.NguoiNhanId).IsRequired(false);
        builder.Property(x => x.IsGlobal).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.DaDoc).IsRequired();
        builder.Property(x => x.ChiHoId).IsRequired(false);
        builder.Property(x => x.HoId).IsRequired(false);
        
        // Relationships
        builder.HasOne(x => x.ChiHo)
            .WithMany()
            .HasForeignKey(x => x.ChiHoId)
            .OnDelete(DeleteBehavior.SetNull);
            
        builder.HasOne(x => x.Ho)
            .WithMany()
            .HasForeignKey(x => x.HoId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
