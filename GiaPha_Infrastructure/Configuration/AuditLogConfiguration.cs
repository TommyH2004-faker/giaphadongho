using GiaPha_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiaPha_Infrastructure.Configuration;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id)
             .HasDefaultValueSql("(UUID())")
             .ValueGeneratedOnAdd();
            builder.Property(x => x.EntityName).IsRequired();
            builder.Property(x => x.EntityId).IsRequired();
            builder.Property(x => x.Action).IsRequired();
            builder.Property(x => x.ChangedAt).IsRequired();
            builder.Property(x => x.ChangedBy).IsRequired(false);
            builder.Property(x => x.OldValues).IsRequired(false);
            builder.Property(x => x.NewValues).IsRequired(false);
    }
}
