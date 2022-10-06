using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class Gastos
    {

        public int IdGasto { get; set; }
        public string Nombre { get; set; }
        public decimal Monto { get; set; }

        public string Descripcion { get; set; }
    }
}
