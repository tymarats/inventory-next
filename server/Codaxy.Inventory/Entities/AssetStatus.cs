#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codaxy.Inventory.Entities;

public class AssetStatus : IIdentifiable<Guid>
{
    public Guid Id { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }

    public ICollection<AssetSubstatus> AssetSubstatus { get; set; }
}
