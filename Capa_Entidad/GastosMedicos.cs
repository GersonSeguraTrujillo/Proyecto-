using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public  class GastosMedicos
    {
        public int IdCita { get; set; }
  
        public Examen oExamen { get; set; }
        public int Cantidad { get; set; }
        public string descripcion { get; set; }

    }
}
