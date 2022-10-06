using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public class DescripcionCita
    {

        public int IdDescripcionCita { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int Idtipo { get; set; }
        public string descripcion { get; set; }

    }
}
