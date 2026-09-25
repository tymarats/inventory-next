#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codaxy.Inventory.Entities;

public class SoftwareOrService : IIdentifiable<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid SoftwareOrServiceCategoryId { get; set; }
    public Guid ManufacturerId { get; set; }
    public string Url { get; set; }

    public ICollection<Volume> Volumes { get; set; }

    public SoftwareOrServiceCategory SoftwareOrServiceCategory { get; set; }
    public Manufacturer Manufacturer { get; set; }
}
