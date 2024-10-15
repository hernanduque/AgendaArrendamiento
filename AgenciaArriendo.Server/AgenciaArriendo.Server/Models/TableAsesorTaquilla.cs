using System;
using System.Collections.Generic;

namespace AgenciaArriendo.Server.Models;

public partial class TableAsesorTaquilla
{
    public int Codigo { get; set; }

    public string? CodAsesor { get; set; }

    public int? CodTaquilla { get; set; }
}
