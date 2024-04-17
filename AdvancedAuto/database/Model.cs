using System;
using System.Collections.Generic;

namespace AdvancedAuto.database;

public partial class Model
{
    public int Id { get; set; }

    public int? BrandId { get; set; }

    public string? Model1 { get; set; }

    public virtual Brand? Brand { get; set; }
}
