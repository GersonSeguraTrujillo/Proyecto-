using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidad;
namespace Capa_Negocio
{
    public class CN_GastosMedicos
    {
        private CD_GastosMedicos objCapaDato = new CD_GastosMedicos();


        public List<GastosMedicos> ListarGastosMedicos(int IdCita)
        {
            return objCapaDato.Listar(IdCita);


        }

        public List<GastosMedicos> ListarMedicamento(int IdCita)
        {
            return objCapaDato.ListarMedicamento(IdCita);


        }

        public int Registrar(GastosMedicos obj, out string Mensaje)
        {
            Mensaje = String.Empty;

         if (obj.IdCita ==0)
            {
                Mensaje = "No puede estar vacion ";
            }
            else if (obj.oExamen.IdDescripcionCita == 0)
            {
                Mensaje = "Debe selecionar ";
            }
            else if (obj.Cantidad == 0)
            {
                Mensaje = "No puede estar vacia la candidad ";
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


        public bool Eliminar(int id,int i ,out string Mensaje)
        {
            return objCapaDato.Eliminar(id, i,out Mensaje);
        }







    }
}