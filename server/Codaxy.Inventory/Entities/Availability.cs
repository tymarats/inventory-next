#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codaxy.Inventory.Entities;

public class Availability : IIdentifiable<Guid>
{
    public Guid Id { get; set; }
    public string Level { get; set; }
    public int Weight { get; set; }
    public string Description { get; set; }

    public ICollection<Asset> Asset { get; set; }
}
