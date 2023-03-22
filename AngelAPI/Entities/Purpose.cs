using System;
using System.Collections.Generic;

namespace AngelAPI.Entities;

public partial class Purpose
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; } = new List<Application>();
}
