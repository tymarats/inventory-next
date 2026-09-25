#nullable disable

using System;
using System.Collections.Generic;

namespace Codaxy.Inventory.Entities;

public class ElectronicDeviceTag : IIdentifiable<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<ElectronicDeviceTypeElectronicDeviceTag> Types { get; set; }
}
