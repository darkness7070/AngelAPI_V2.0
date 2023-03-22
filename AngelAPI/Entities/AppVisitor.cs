using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AngelAPI.Entities;

public partial class AppVisitor
{
    public int Id { get; set; }

    public int IdVisitor { get; set; }

    public int IdApp { get; set; }
    public virtual Application IdAppNavigation { get; set; } = null!;
    public virtual Visitor IdVisitorNavigation { get; set; } = null!;
}
