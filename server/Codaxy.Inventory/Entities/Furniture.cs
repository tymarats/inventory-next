#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codaxy.Inventory.Entities;

public class Furniture : IIdentifiableReadOnly<Guid>
{
    public Guid Id => AssetId;

    public Guid AssetId { get; set; }
    public Guid? FurnitureTypeId { get; set; }
    public string Model { get; set; }

    public Asset Asset { get; set; }
    public FurnitureType FurnitureType { get; set; }
}
