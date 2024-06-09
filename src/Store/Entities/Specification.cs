using System;
using System.Collections.Generic;

namespace Forpost.Store.Entities;

public partial class Specification
{
    public string? Name { get; set; }

    public string? Designator { get; set; }

    public string? Description { get; set; }

    public string? NameElement { get; set; }

    public string? Manufacturer { get; set; }

    public int? Quantity { get; set; }
}
