using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
  public   class CN_GastosFundacion
    {

        private CD_GastosFundacion objCapaDato = new CD_GastosFundacion();

        public List<GastosFundacion> Listar()
        {
            return objCapaDato.Listar();
        }

        public string Registrar(GastosFundacion obj, out string Mensaje)
        {
            Mensaje = String.Empty;

            //if (obj.oFundacion.IdFundacion == 0)
            //  {
            //      Mensaje = "Debe Seleccionar la fundacin para llevar el control del gasto";
            //  }

            //  else if (obj.oFundacion.IdFundacion == 0)
            //  {
            //      Mensaje = "Debe Seleccionar la fundacin para llevar el control del gasto quiere registra";
            //  }

            if (obj.oFundacion.IdFundacion == 0)
            {
                Mensaje = "Debe Seleccionar la fundacin para llevar el control del gasto";
            }

            else if (obj.oFundacion.IdFundacion == 0)
            {
                Mensaje = "Debe Seleccionar la fundacin para llevar el control del gasto quiere registra";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);

            }
            else
            {


                return null ;
            }
        }

        public bool Editar(GastosFundacion obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oFundacion.IdFundacion == 0)
            {
                Mensaje = "Debe Seleccionar la fundacin para llevar el control del gasto";
            }

            else if (obj.oFundacion.IdFundacion == 0)
            {
                Mensaje = "Debe Seleccionar la fundacin para llevar el control del gasto quiere registra";
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
