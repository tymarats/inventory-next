#nullable disable

using Codaxy.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codaxy.Inventory.Persistence.Configurations;

public class ElectronicDeviceConfiguration : IEntityTypeConfiguration<ElectronicDevice>
{
    public void Configure(EntityTypeBuilder<ElectronicDevice> builder)
    {
        builder.HasKey(a => a.AssetId);
    }
}
