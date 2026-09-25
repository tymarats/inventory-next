#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codaxy.Inventory.Entities;

public class AssetCategory : IIdentifiable<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<AssetType> AssetType { get; set; }
}
