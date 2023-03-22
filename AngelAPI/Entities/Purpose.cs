using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AngelAPI.Entities;

public partial class Purpose
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Application> Applications { get; } = new List<Application>();
}
