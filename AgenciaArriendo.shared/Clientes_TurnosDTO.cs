using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaArriendo.shared
{
    public class Clientes_TurnosDTO
    {
        public string? Strcedula { get; set; }
        [Range(1800000, int.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
        public TipoPersonaDTO? Strcodigotipopersona { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public TipoDocumentoDTO? Strcodigotipodocumento { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string? Strnombres { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string? Strapellidos { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string? Strtelefonofijo { get; set; }

        public string? Strtelefonocelular { get; set; }

        public string? Stremail { get; set; }
    }
}
