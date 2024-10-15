using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace AgenciaArriendo.shared
{
    public class ClientesCitaDTO
    {
        
        public string? STRCEDULA { get; set; }
        [Range(1800000, int.MaxValue, ErrorMessage = "El campo {0} es requerido.")]

        public string? STRCODIGOAPARTAMENTOVISITA { get; set; }
        public string? STRCODIGOASESORASIGNADO { get; set; }
        public string? STRFECHARESERVA { get; set; }
        public string? STRHORARESERVA { get; set; }
        public string? STRFECHAREALVISITA { get; set; }
        public string? STRHORAREALVISITA { get; set; }
        public string? STRESTADOVISITA { get; set; }
        public string? STRCODIGORESERVA { get; set; }

        //datos para el email

        public string? fecha { get; set; }
        public string? strhorareservax { get; set; }
        public string? StrSede { get; set; }

        public string? nombreasesor { get; set; }

        public string? stremailcliente { get; set; }
    }
}
