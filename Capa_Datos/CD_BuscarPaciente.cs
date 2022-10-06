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
   public class CD_BuscarPaciente
    {
        public List<BuscarPaciente> Buscar(int  IdCita)
        {
            List<BuscarPaciente> lista = new List<BuscarPaciente>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_Buscar_Paciente", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new BuscarPaciente()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),
                                Nombre = dr["Nombre"].ToString(),
                                Cintomas = dr["Cintomas"].ToString(),
                                Resultados = dr["Resultados"].ToString(),


                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<BuscarPaciente>();
            }

            return lista;
        }

        public BuscarPaciente VerPaciente(int IdCita)
        {
            BuscarPaciente objeto = new BuscarPaciente();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("SP_Buscar_Paciente", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            objeto = new BuscarPaciente()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),
                                Nombre = dr["Nombre"].ToString(),
                                Cintomas = dr["Cintomas"].ToString(),
                                Resultados = dr["Resultados"].ToString(),
                            };
                        }
                    }

                }
            }
            catch
            {
                objeto = new BuscarPaciente();
            }

            return objeto;
        }



    }
}
