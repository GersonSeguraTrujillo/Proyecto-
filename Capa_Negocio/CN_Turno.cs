using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;


namespace Capa_Negocio
{
      public class CN_Turno
    {
        private CD_Turno objCapaDato = new CD_Turno();

        public List<Turno> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Turno obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Horario) || string.IsNullOrWhiteSpace(obj.Horario))
            {
                Mensaje = "El campo horario no puede estar vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);

            }
            else
            {


                return 0;
            }

        }

        public bool Editar(Turno obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Horario) || string.IsNullOrWhiteSpace(obj.Horario))
            {
                Mensaje = "El campo horario no puede estar vacio"; ;
            }
            

            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }




    }
}
