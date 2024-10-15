using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaArriendo.shared
{
    public class AsesorHorarioDTO
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
}

