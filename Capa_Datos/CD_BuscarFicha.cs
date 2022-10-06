using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Entidad;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Capa_Datos
{
  public  class CD_BuscarFicha
    {
        public BuscarFicha VerFicha(int IdCita)
        {
            BuscarFicha objeto = new BuscarFicha();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("SP_Buscar_Ficha", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            objeto = new BuscarFicha()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                Cintomas = dr["Cintomas"].ToString(),
                                Especialista = dr["Especialista"].ToString(),
                                Paciente = dr["Paciente"].ToString(),
                                Resultados = dr["Resultados"].ToString(),
                            };
                        }
                    }

                }
            }
            catch
            {
                objeto = new BuscarFicha();
            }

            return objeto;
        }
    }
}
