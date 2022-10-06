using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
  public  class Cita
    {
        public int IdCita { get; set; }
        public Medico oMedico { get; set; }
        public Paciente oPaciente { get; set; }
        public string Cintomas { get; set; }
        public Especialista oEspecialista { get; set; }
        public Enfermero oEnfermero { get; set; }
        public decimal PrecioCita { get; set; }
        public Estado oEstado { get; set; }
        public int NoTurno { get; set; }
        public string FechaRegistro { get; set; }
        

    }
}
