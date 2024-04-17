using System;
using System.Collections.Generic;

namespace AdvancedAuto.database;

public partial class Brand
{
    public int Id { get; set; }

    public string? Brand1 { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
