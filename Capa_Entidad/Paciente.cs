using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
  public    class Paciente
    {
        public int NoPaciente { get; set; }
        public int Dpi { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Enfermedad { get; set; }
        public int edad { get; set; }
        public string Correo { get; set; }

    }
}
