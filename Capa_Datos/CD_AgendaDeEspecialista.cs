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
   public class CD_AgendaDeEspecialista
    {
        public List<AgendaDeEspecialista> Listar(int IdEspecialidad)
        {
            List<AgendaDeEspecialista> lista = new List<AgendaDeEspecialista>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("Agenda", oconexion);
                    cmd.Parameters.AddWithValue("IdEspecialidad", IdEspecialidad);

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new AgendaDeEspecialista()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),
                                Paciente = dr["Paciente"].ToString(),
                                Especialidad = dr["Especialidad"].ToString(),
                                Horario = dr["Horario"].ToString()





                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<AgendaDeEspecialista>();
            }

            return lista;
        }
    }
}
