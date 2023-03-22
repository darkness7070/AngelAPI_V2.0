using System;
using System.Collections.Generic;

namespace AngelAPI.Entities;

public partial class Subdivision
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<WorkerSubdivision> WorkerSubdivisions { get; } = new List<WorkerSubdivision>();
}
