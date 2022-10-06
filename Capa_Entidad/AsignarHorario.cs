using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public class AsignarHorario
    {
        public int IdCita { get; set; }
        public string Paciente { get; set; }
        public string Especialidad { get; set; }
        public Estado oEstado { get; set; }
        public string Horario { get; set; }
        public Turno oTurno { get; set; }
    }
}
