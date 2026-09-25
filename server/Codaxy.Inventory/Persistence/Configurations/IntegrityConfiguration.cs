#nullable disable

using Codaxy.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codaxy.Inventory.Persistence.Configurations;

public class IntegrityConfiguration : IEntityTypeConfiguration<Integrity>
{
    public void Configure(EntityTypeBuilder<Integrity> builder)
    {
        builder.Property(i => i.Level).HasMaxLength(15);
        builder.Property(i => i.Description).HasMaxLength(1000);
    }
}
