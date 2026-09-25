#nullable disable

using Codaxy.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codaxy.Inventory.Persistence.Configurations;

public class AvailabilityConfiguration : IEntityTypeConfiguration<Availability>
{
    public void Configure(EntityTypeBuilder<Availability> builder)
    {
        builder.Property(a => a.Level).HasMaxLength(15);
        builder.Property(a => a.Description).HasMaxLength(1000);
    }
}
