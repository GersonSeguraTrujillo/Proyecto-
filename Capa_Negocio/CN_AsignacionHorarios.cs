using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
     public  class CN_AsignacionHorarios
    {
        private CD_AsignacionHorario objCapaDato = new CD_AsignacionHorario();

        public List<AsignarHorario> Listar()
        {

            return objCapaDato.Listar();
        }

        public bool AsignacionHorario(AsignarHorario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

           
             if (obj.oEstado.IdEstado == 0)
            {
                Mensaje = "Falta el estado de la cita";
            }
        



            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.AsignarHorario(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }


    }
}
