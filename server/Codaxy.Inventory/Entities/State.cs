#nullable disable

using System;

namespace Codaxy.Inventory.Entities;

public class State : IIdentifiable<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CountryCode { get; set; }

    public Country Country { get; set; }
}
