#nullable disable

using System;
using System.Collections.Generic;

namespace Codaxy.Inventory.Entities;

public class Location : IIdentifiable<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CountryCode { get; set; }
    public Guid? StateId { get; set; }
    public Guid CityId { get; set; }
    public string PostalCode { get; set; }
    public string Street { get; set; }
    public int? HouseNumber { get; set; }
    public int? Floor { get; set; }
    public string Room { get; set; }

    public Country Country { get; set; }
    public State State { get; set; }
    public City City { get; set; }

    public ICollection<Asset> Asset { get; set; }
}
