using System;
using System.Collections.Generic;

namespace AngelAPI.Entities;

public partial class Application
{
    public int Id { get; set; }

    public DateOnly ValidatyFrom { get; set; }

    public DateOnly ValidatyTo { get; set; }

    public int IdPurpose { get; set; }

    public int IdSubdivision { get; set; }

    public byte[]? Passport { get; set; }

    public TimeOnly? ArrivalTime { get; set; }

    public TimeOnly? LeavingTime { get; set; }

    public bool IsSingle { get; set; }

    public int Status { get; set; }

    public virtual ICollection<AppUser> AppUsers { get; } = new List<AppUser>();

    public virtual ICollection<AppVisitor> AppVisitors { get; } = new List<AppVisitor>();

    public virtual Purpose IdPurposeNavigation { get; set; } = null!;

    public virtual WorkerSubdivision IdSubdivisionNavigation { get; set; } = null!;
}
