using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AngelAPI.Entities;

public partial class WorkerSubdivision
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonIgnore]
    public int IdWorker { get; set; }
    [JsonIgnore]
    public int IdSubdivision { get; set; }
    [JsonIgnore]
    public virtual ICollection<Application> Applications { get; } = new List<Application>();

    public virtual Subdivision IdSubdivisionNavigation { get; set; } = null!;

    public virtual Worker IdWorkerNavigation { get; set; } = null!;
}
