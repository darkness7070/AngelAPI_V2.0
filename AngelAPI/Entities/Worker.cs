using System;
using System.Collections.Generic;

namespace AngelAPI.Entities;

public partial class Worker
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    public virtual ICollection<WorkerSubdivision> WorkerSubdivisions { get; } = new List<WorkerSubdivision>();
}
