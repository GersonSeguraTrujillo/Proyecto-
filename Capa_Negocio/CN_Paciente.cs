using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
  public   class CN_Paciente
    {
        private CD_Paciente objCapaDato = new CD_Paciente();

        public List<Paciente> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Paciente obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (obj.Dpi ==0)
            {
                Mensaje = "El dpi del paciente  no puede ser vacio";
            }

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del paciente  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje = "El apillido no peuede estar vascio";
            }
          
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo no peuede estar vascio";
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



        public bool Editar(Paciente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Dpi == 0)
            {
                Mensaje = "El dpi del paciente  no puede ser vacio";
            }

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del paciente  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje = "El apillido no peuede estar vascio";
            }
            else if (obj.edad == 0)
            {
                Mensaje = "La del paciente  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo no peuede estar vascio";
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
