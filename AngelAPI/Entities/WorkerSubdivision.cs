using System;
using System.Collections.Generic;

namespace AngelAPI.Entities;

public partial class WorkerSubdivision
{
    public int Id { get; set; }

    public int IdWorker { get; set; }

    public int IdSubdivision { get; set; }

    public virtual ICollection<Application> Applications { get; } = new List<Application>();

    public virtual Subdivision IdSubdivisionNavigation { get; set; } = null!;

    public virtual Worker IdWorkerNavigation { get; set; } = null!;
}
