#nullable disable

using System.Linq;
using Codaxy.Inventory.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codaxy.Inventory.Persistence;

public class InventoryContext : DbContext
{
    public InventoryContext(DbContextOptions options)
        : base(options) { }

    protected InventoryContext() { }

    /// <summary>
    /// The naming convention lives here rather than beside each <c>UseNpgsql</c>: three places
    /// build this context, and one that configures the model differently from the others builds a
    /// model that no longer matches the migrations snapshot.
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSnakeCaseNamingConvention();

    public DbSet<Asset> Assets => Set<Asset>();
    public DbSet<AssetCategory> AssetCategories => Set<AssetCategory>();
    public DbSet<AssetType> AssetTypes => Set<AssetType>();
    public DbSet<AssetStatus> AssetStatuses => Set<AssetStatus>();
    public DbSet<AssetSubstatus> AssetSubstatuses => Set<AssetSubstatus>();
    public DbSet<Confidentiality> Confidentialities => Set<Confidentiality>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<State> States => Set<State>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Importance> Importances => Set<Importance>();
    public DbSet<Availability> Availabilities => Set<Availability>();
    public DbSet<Integrity> Integrities => Set<Integrity>();
    public DbSet<LicenseClass> LicenseClasses => Set<LicenseClass>();
    public DbSet<LicenseCategory> LicenseCategories => Set<LicenseCategory>();
    public DbSet<LicenseType> LicenseTypes => Set<LicenseType>();
    public DbSet<LicenseExpirationModel> LicenseExpirationModels => Set<LicenseExpirationModel>();
    public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
    public DbSet<Vendor> Vendors => Set<Vendor>();
    public DbSet<License> Licenses => Set<License>();
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Furniture> Furnitures => Set<Furniture>();
    public DbSet<FurnitureType> FurnitureTypes => Set<FurnitureType>();
    public DbSet<Sequence> Sequences => Set<Sequence>();
    public DbSet<SoftwareOrService> SoftwareOrServices => Set<SoftwareOrService>();
    public DbSet<SoftwareOrServiceCategory> SoftwareOrServiceCategories =>
        Set<SoftwareOrServiceCategory>();
    public DbSet<Activation> Activations => Set<Activation>();
    public DbSet<Volume> Volumes => Set<Volume>();
    public DbSet<VolumeType> VolumeTypes => Set<VolumeType>();
    public DbSet<LicenseModel> LicenseModels => Set<LicenseModel>();
    public DbSet<BusinessEntity> BusinessEntities => Set<BusinessEntity>();
    public DbSet<Period> Periods => Set<Period>();
    public DbSet<Currency> Currencies => Set<Currency>();
    public DbSet<MaintenanceContract> MaintenanceContracts => Set<MaintenanceContract>();
    public DbSet<MaintenanceType> MaintenanceTypes => Set<MaintenanceType>();
    public DbSet<ElectronicDevice> ElectronicDevices => Set<ElectronicDevice>();
    public DbSet<ElectronicDeviceType> ElectronicDeviceTypes => Set<ElectronicDeviceType>();
    public DbSet<ElectronicDeviceTag> ElectronicDeviceTags => Set<ElectronicDeviceTag>();
    public DbSet<ElectronicDeviceTypeElectronicDeviceTag> ElectronicDeviceTypeElectronicDeviceTags =>
        Set<ElectronicDeviceTypeElectronicDeviceTag>();
    public DbSet<Information> Informations => Set<Information>();
    public DbSet<InformationType> InformationTypes => Set<InformationType>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<InformationTag> InformationTags => Set<InformationTag>();
    public DbSet<InformationTagInformation> InformationTagInformations =>
        Set<InformationTagInformation>();
    public DbSet<InformationLocation> InformationLocations => Set<InformationLocation>();
    public DbSet<VirtualMachine> VirtualMachines => Set<VirtualMachine>();
    public DbSet<Software> Softwares => Set<Software>();
    public DbSet<Cloud> Clouds => Set<Cloud>();

    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryContext).Assembly);

        // A table is named after its entity, not after its DbSet: `person`, not `persons`. The
        // DbSets are pluralised mechanically, so nobody has to argue about Informations or
        // Confidentialities, and none of that reaches the schema. An explicitly set name wins
        // over the naming convention, so it is spelled here the way the convention spells
        // columns.
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (entityType.ClrType is not { } clrType || entityType.IsOwned())
                continue;

            entityType.SetTableName(ToSnakeCase(clrType.Name));
        }
    }

    private static string ToSnakeCase(string name) =>
        string.Concat(
            name.Select(
                (c, i) =>
                    char.IsUpper(c) && i > 0
                        ? "_" + char.ToLowerInvariant(c)
                        : char.ToLowerInvariant(c).ToString()
            )
        );
}
