using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
  public class CN_AgendaDeEspecialista
    {

        private CD_AgendaDeEspecialista objCapaDato = new CD_AgendaDeEspecialista();


        public List<AgendaDeEspecialista> ListarAgendaEspecialista(int IdEspecialidad)
        {
            return objCapaDato.Listar(IdEspecialidad);


        }
    }
}
