using System;
using System.Collections.Generic;

namespace Forpost.Store.Entities;

public partial class Works
{
    public int Id { get; set; }

    public string? NumberPrint { get; set; }

    public string? Name { get; set; }

    public string? Klient { get; set; }

    public string? Account { get; set; }

    public string? TaskName { get; set; }

    public string? Amount { get; set; }

    public DateOnly? DateStart { get; set; }

    public DateOnly? DateEnd { get; set; }

    public long? IdName { get; set; }

    public int? IdOrderBlocks { get; set; }

    public string? Status { get; set; }

    public string? SheetName { get; set; }

    public bool? StorageFlag { get; set; }
}
