using System;
using System.Collections.Generic;

namespace AgenciaArriendo.Server.Models;

public partial class TableHorario
{
    public string? Strcodigohorario { get; set; }

    public string? Strhorario { get; set; }

    public int? Orden { get; set; }

    public string? Strestado { get; set; }
}
