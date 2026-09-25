#nullable disable

using Codaxy.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codaxy.Inventory.Persistence.Configurations;

public class ConfidentialityConfiguration : IEntityTypeConfiguration<Confidentiality>
{
    public void Configure(EntityTypeBuilder<Confidentiality> builder)
    {
        builder.Property(c => c.Level).HasMaxLength(15);
        builder.Property(c => c.Description).HasMaxLength(1000);
    }
}
