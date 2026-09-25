#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codaxy.Inventory.Entities;

public class VolumeType : IIdentifiable<int>
{
    public int Id { get; set; }
    public string Text { get; set; }
}
