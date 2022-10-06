using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
  public  class CN_BuscarPaciente
    {
        private CD_BuscarPaciente objCapaDato = new CD_BuscarPaciente();


        public List<BuscarPaciente> Buscar(int IdCita)
        {
            return objCapaDato.Buscar(IdCita);
        }

        public BuscarPaciente VerPaciente( int IdCita)
        {

            return objCapaDato.VerPaciente(IdCita);
        }



    }
}
