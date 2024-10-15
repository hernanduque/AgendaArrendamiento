using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaArriendo.shared
{
    public class ResponseAPI<T>
    {
        public bool Escorrecto {  get; set; }
        public T? Valor { get; set; }
        public String? Mensaje { get; set; }

    }
}
