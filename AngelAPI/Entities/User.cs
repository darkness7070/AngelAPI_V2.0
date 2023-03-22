using System;
using System.Collections.Generic;

namespace AngelAPI.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Token { get; set; }

    public virtual ICollection<AppUser> AppUsers { get; } = new List<AppUser>();
}
