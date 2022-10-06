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
    public    class CD_AsignacionHorario
    {
        public List<AsignarHorario> Listar()
        {
            List<AsignarHorario> lista = new List<AsignarHorario>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("select c.IdCita,CONCAT(p.Nombre,' ',p.Apellido)Paciente,");
                    sb.AppendLine("esp.Nombre[Especialidad],e.IdEstado, e.Descripcion[Estado],t.NoTurno, t.Horario");
                    sb.AppendLine("from cita c");
                    sb.AppendLine("inner join Paciente p on p.NoPaciente = c.NoPaciente");
                    sb.AppendLine("inner join Especialista es on  es.IdEspecialista = c.IdEspecialista");
                    sb.AppendLine("inner join Especialidad esp on esp.IdEspecialidad = es.IdEspecialidad");
                    sb.AppendLine("inner join Estado e on e.IdEstado= c.IdEstado");
                    sb.AppendLine("left join Turno t on t.NoTurno = c.NoTurno");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new AsignarHorario()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),
                                Paciente = dr["Paciente"].ToString(),
                                Especialidad = dr["Especialidad"].ToString(),
                                oEstado = new Estado() { IdEstado = Convert.ToInt32(dr["IdEstado"]), Descripcion = dr["Estado"].ToString()},
                                oTurno = new Turno() { NoTurno = Convert.ToInt32(dr["NoTurno"]), Horario = dr["Horario"].ToString() },
                            }
                            );
                        }
                    }

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                lista = new List<AsignarHorario>();
            }

            return lista;
        }

        public bool AsignarHorario(AsignarHorario obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_Asignacion_Horarios", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", obj.IdCita);

                    cmd.Parameters.AddWithValue("IdEstado", obj.oEstado.IdEstado);
                    cmd.Parameters.AddWithValue("NoTurno", obj.oTurno.NoTurno);

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value.ToString());
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }






    }
}
