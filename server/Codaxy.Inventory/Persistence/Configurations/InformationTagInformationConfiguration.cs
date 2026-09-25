#nullable disable

using Codaxy.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codaxy.Inventory.Persistence.Configurations;

public class InformationTagInformationConfiguration
    : IEntityTypeConfiguration<InformationTagInformation>
{
    public void Configure(EntityTypeBuilder<InformationTagInformation> builder)
    {
        builder.HasKey(it => new { it.InformationId, it.InformationTagId });

        builder
            .HasOne(it => it.Information)
            .WithMany(e => e.Tags)
            .HasForeignKey(it => it.InformationId);

        builder
            .HasOne(it => it.InformationTag)
            .WithMany(e => e.Informations)
            .HasForeignKey(it => it.InformationTagId);
    }
}
