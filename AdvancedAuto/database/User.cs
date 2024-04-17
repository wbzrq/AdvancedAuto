using System;
using System.Collections.Generic;

namespace AdvancedAuto.database;

public partial class User
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Pass { get; set; }
}
