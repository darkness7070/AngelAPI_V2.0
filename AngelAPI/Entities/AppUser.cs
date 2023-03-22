using System;
using System.Collections.Generic;

namespace AngelAPI.Entities;

public partial class AppUser
{
    public int Id { get; set; }

    public int IdApp { get; set; }

    public int IdUser { get; set; }

    public virtual Application IdAppNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
