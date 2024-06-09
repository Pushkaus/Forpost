using System;
using System.Collections.Generic;

namespace Forpost.Store.Store;

public partial class TaskStorage
{
    public int Id { get; set; }

    public string? TaskName { get; set; }

    public string? NumberRm { get; set; }

    public DateOnly? DateInsert { get; set; }

    public int? IdOrderBlocksInTask { get; set; }

    public int? IdOrderBlocksInSetup { get; set; }
}
