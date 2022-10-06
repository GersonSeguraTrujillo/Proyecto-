using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class CN_Especialista
    {
        private CD_Especialista objCapaDato = new CD_Especialista();

        public List<Especialista> Listar()
        {

            return objCapaDato.Listar();
        }

        public string Registrar(Especialista obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El Nombre del Producto no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje = "el nombre del esppecialista no puede ser vacio";
            }
            else if (obj.oEspecialidad.IdEspecialidad == 0)
            {
                Mensaje = "Debe Seleccionar una especialidad para el el especialista";
            }
      
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return null;
            }

        }

        public bool Editar(Especialista obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El Nombre del Producto no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Apellido))
            {
                Mensaje = "el nombre del esppecialista no puede ser vacio";
            }
            else if (obj.oEspecialidad.IdEspecialidad == 0)
            {
                Mensaje = "Debe Seleccionar una especialidad para el el especialista";
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
