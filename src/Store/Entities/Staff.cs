using System;
using System.Collections.Generic;

namespace Forpost.Store.Entities;

public partial class Staff
{
    public long Id { get; set; }

    /// <summary>
    /// ФИО сотрудника
    /// </summary>
    public string Name { get; set; } = null!;

    public string Post { get; set; } = null!;

    public int? NumberPrint { get; set; }

    public int? NumberCabinet { get; set; }

    public DateTime? LastDate { get; set; }

    public string? LastUser { get; set; }

    public string? Manager { get; set; }
    public string? Password { get; set; }
}
