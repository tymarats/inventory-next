#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codaxy.Inventory.Entities;

public class AssetType : IIdentifiable<Guid>
{
    public Guid Id { get; set; }
    public Guid AssetCategoryId { get; set; }
    public string Name { get; set; }

    public AssetCategory AssetCategory { get; set; }
}
