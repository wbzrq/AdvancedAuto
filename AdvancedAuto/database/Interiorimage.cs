using System;
using System.Collections.Generic;

namespace AdvancedAuto.database;

public partial class Interiorimage
{
    public int Id { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public string? InteriorPath { get; set; }
}
