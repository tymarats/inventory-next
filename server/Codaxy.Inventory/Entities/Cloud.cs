#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codaxy.Inventory.Entities;

public class Cloud : IIdentifiable<Guid>
{
    public Guid Id { get; set; }
    public Guid VolumeId { get; set; }
    public string Name { get; set; }
    public string ManagementURL { get; set; }

    public Volume Volume { get; set; }
}
