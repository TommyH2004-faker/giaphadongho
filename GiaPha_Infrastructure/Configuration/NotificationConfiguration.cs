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
        builder.Property(x => x.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
    }
}
