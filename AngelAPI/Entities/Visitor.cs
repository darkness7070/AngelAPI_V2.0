using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AngelAPI.Entities;

public partial class Visitor
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Organization { get; set; } = null!;

    public string Notes { get; set; } = null!;

    public DateOnly DateBirth { get; set; }

    public string Series { get; set; } = null!;

    public string Numbers { get; set; } = null!;

    public bool? IsBlacklist { get; set; }
    [JsonIgnore]
    public virtual ICollection<AppVisitor> AppVisitors { get; } = new List<AppVisitor>();
}
