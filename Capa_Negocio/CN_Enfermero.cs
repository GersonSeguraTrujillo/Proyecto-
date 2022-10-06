using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class CN_Enfermero
    {
        private CD_Enfermero objCapaDato = new CD_Enfermero ();

        public List<Enfermero> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Enfermero obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del enfermero no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje = "El apillido no peuede estar vascio";
            }
            
            else if (string.IsNullOrEmpty(obj.EstudiosRealizados) || string.IsNullOrWhiteSpace(obj.EstudiosRealizados))
            {
                Mensaje = "Los estudios realizados no puede estar vacio no peuede estar vascio";
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

        public bool Editar(Enfermero obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del enfermero no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje = "El apillido no peuede estar vascio";
            }

            else if (string.IsNullOrEmpty(obj.EstudiosRealizados) || string.IsNullOrWhiteSpace(obj.EstudiosRealizados))
            {
                Mensaje = "Los estudios realizados no puede estar vacio no peuede estar vascio";
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
