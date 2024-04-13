using System;
using System.Collections.Generic;

namespace AdvancedAuto.database;

public partial class Carimage
{
    public int Id { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public string? Color { get; set; }

    public string? View { get; set; }

    public string? ImagePath { get; set; }
}
