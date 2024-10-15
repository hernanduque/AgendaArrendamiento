using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaArriendo.shared
{
    public class ApartamentoVisitumDTO
    {
        public string? Strcodigo { get; set; }

        public string? Strapartamentovisita { get; set; }

        public string? Strestado { get; set; }

        public int? Strcodigosector { get; set; }

        public SectorApartamentoDTO? StrcodigosectorNavigation { get; set; }
    }
}
