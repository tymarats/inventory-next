#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codaxy.Inventory.Entities;

public class LicenseCategory : IIdentifiable<Guid>
{
    public Guid Id { get; set; }
    public string Text { get; set; }
}
