using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public class AgendaDeEspecialista
    {
        public int IdCita { get; set; }

        public string Paciente { get; set; }
        public string Especialidad { get; set; }
        public string Horario { get; set; }

    }
}
