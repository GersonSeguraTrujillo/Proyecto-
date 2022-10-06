using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
   public  class CN_BuscarFicha
    {
        private CD_BuscarFicha objCapaDato = new CD_BuscarFicha();
        public BuscarFicha VerFicha(int IdCita)
        {

            return objCapaDato.VerFicha(IdCita);
        }
    }
}
