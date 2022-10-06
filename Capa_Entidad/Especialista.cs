using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public class Especialista
    {

        public int IdEspecialista { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Especialidad oEspecialidad{ get; set; }
    }
}
