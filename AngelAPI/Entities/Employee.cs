using System;
using System.Collections.Generic;

namespace AngelAPI.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public int IdRole { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
