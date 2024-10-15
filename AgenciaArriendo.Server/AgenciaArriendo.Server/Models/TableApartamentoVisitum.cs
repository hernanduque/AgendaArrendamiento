using System;
using System.Collections.Generic;

namespace AgenciaArriendo.Server.Models;

public partial class TableApartamentoVisitum
{
    public string? Strcodigo { get; set; }

    public string? Strapartamentovisita { get; set; }

    public string? Strestado { get; set; }

    public int? Strcodigosector { get; set; }

    public virtual TableSectorApartamento? StrcodigosectorNavigation { get; set; }
    public virtual TableEstado? StrestadoNavigation { get;  set; }
}
