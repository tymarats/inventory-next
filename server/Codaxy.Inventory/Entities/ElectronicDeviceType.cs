#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codaxy.Inventory.Entities;

public class ElectronicDeviceType : IIdentifiable<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool HoldLicences { get; set; }
    public string Description { get; set; }
    public virtual ICollection<ElectronicDeviceTypeElectronicDeviceTag> Tags { get; set; }
}
