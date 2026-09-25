#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codaxy.Inventory.Entities;

public class ElectronicDevice : IIdentifiableReadOnly<Guid>
{
    public Guid Id => AssetId;
    public Guid AssetId { get; set; }
    public Guid? ManufacturerId { get; set; }
    public DateOnly? ManufacturingDate { get; set; }
    public DateOnly? GuaranteeExpirationDate { get; set; }
    public string GuaranteeNumber { get; set; }
    public string SerialNumber { get; set; }
    public string ModelCode { get; set; }
    public string ModelName { get; set; }
    public Guid? ElectronicDeviceTypeId { get; set; }

    public Asset Asset { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public ElectronicDeviceType ElectronicDeviceType { get; set; }
}
