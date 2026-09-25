#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codaxy.Inventory.Entities;

public class InformationLocation : IIdentifiable<Guid>
{
    public Guid Id { get; set; }
    public Guid InformationId { get; set; }
    public Guid? ElectronicDeviceId { get; set; }
    public Guid? VirtualMachineId { get; set; }
    public Guid? SoftwareId { get; set; }
    public Guid? CloudId { get; set; }
    public Guid? PhysicalLocationId { get; set; }
    public string URL { get; set; }

    public Information Information { get; set; }
    public ElectronicDevice ElectronicDevice { get; set; }
    public VirtualMachine VirtualMachine { get; set; }
    public Software Software { get; set; }
    public Cloud Cloud { get; set; }
    public Location PhysicalLocation { get; set; }
}
