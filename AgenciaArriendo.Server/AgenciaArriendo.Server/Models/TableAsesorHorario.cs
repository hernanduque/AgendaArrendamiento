using System;
using System.Collections.Generic;

namespace AgenciaArriendo.Server.Models;

public partial class TableAsesorHorario
{
    public string Strcodigoasesor { get; set; } = null!;

    public string Strcodigohorario { get; set; } = null!;

    public string Strfechareserva { get; set; } = null!;

    public string Strcedulacliente { get; set; } = null!;

    public string Strcodigoapartamentovisita { get; set; } = null!;

    public string Strhorareserva { get; set; } = null!;

    public string Strestadovisita { get; set; } = null!;

    public string Strcodigoreserva { get; set; } = null!;

    public string? Strobservacion { get; set; }

    public string? Strfechavisita { get; set; }

    public string? Dtrhorsvisita { get; set; }
}
