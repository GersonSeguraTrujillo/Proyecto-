using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
 public    class GastosFundacion
    {
        public int NoGasto { get; set; }
        public   Fundacion oFundacion{ get; set; }
        public  Gastos oGastos { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public string  FechaRegistro { get; set; }
    }
}
