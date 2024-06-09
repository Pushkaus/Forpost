using System;
using System.Collections.Generic;

namespace Forpost.Store.Entities;

public partial class StaffRoleStaffView
{
    public long? TelegaId { get; set; }

    public string? SotrTel { get; set; }

    public string? TelegaName { get; set; }

    public string? SotrName { get; set; }

    public string? TelegaPost { get; set; }

    public string? SotrRole { get; set; }

    public int? TelegaPrint { get; set; }

    public string? SotrPrint { get; set; }

    public int? TelegaCabinet { get; set; }

    public string? TelegaManager { get; set; }

    public string? SotrManager { get; set; }

    public DateTime? TelegaLastDate { get; set; }
}
