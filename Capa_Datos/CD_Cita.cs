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
  public  class CD_Cita
    {
        public List<Cita> Listar()
        {
            List<Cita> lista = new List<Cita>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("  Select c.IdCita,c.FechaRegistro,m.IdMedico,m.Nombre[Medico],m.Apellido[apMedico],");
                    sb.AppendLine("p.NoPaciente,p.Nombre[Paciente],p.Apellido, c.Cintomas, e.IdEspecialista,e.Nombre[Especialista],e.Apellido[apEspecialista],");
                    sb.AppendLine("en.IdEnfermero,en.Nombre[Enfermero],en.Apellido[apEnfermero],c.PrecioCita,es.IdEstado,es.Descripcion[Estado]");
                    sb.AppendLine("from cita c");
                    sb.AppendLine("Inner join Medico m on m.IdMedico = c.IdMedico");
                    sb.AppendLine("inner join Paciente p on p.NoPaciente = c.NoPaciente");
                    sb.AppendLine("inner join Especialista e on e.IdEspecialista = c.IdEspecialista");
                    sb.AppendLine("inner join Enfermero en on en.IdEnfermero = c.IdEnfermero");
                    sb.AppendLine("inner join Estado es on es.IdEstado = c.IdEstado");
                    sb.AppendLine("order by c.IdCita desc");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cita()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),
                              
                                oMedico = new Medico() {  IdMedico= Convert.ToInt32(dr["IdMedico"]), Nombre = dr["Medico"].ToString() ,Apellido = dr["apMedico"].ToString() },
                                oPaciente = new Paciente() { NoPaciente = Convert.ToInt32(dr["NoPaciente"]), Nombre = dr["Paciente"].ToString(),Apellido = dr["Apellido"].ToString()},
                                Cintomas = dr["Cintomas"].ToString(),
                                oEspecialista= new Especialista() { IdEspecialista = Convert.ToInt32(dr["IdEspecialista"]), Nombre = dr["Especialista"].ToString(), Apellido = dr["apEspecialista"].ToString() },
                                oEnfermero = new Enfermero() { IdEnfermero = Convert.ToInt32(dr["IdEnfermero"]), Nombre = dr["Enfermero"].ToString(), Apellido = dr["apEnfermero"].ToString() },
                                PrecioCita = Convert.ToDecimal(dr["PrecioCita"]),
                                oEstado = new Estado() { IdEstado = Convert.ToInt32(dr["IdEstado"]), Descripcion = dr["Estado"].ToString() },
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                            }
                            );
                        }
                    }

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                lista = new List<Cita>();
            }

            return lista;
        }


        public string Registrar(Cita obj, out string Mensaje)
        {
            string idautogenerado = null;

            Mensaje = string.Empty;
            try
            {


                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_Registrar_Cita", oconexion);


                    cmd.Parameters.AddWithValue("IdMedico", obj.oMedico.IdMedico);
                    cmd.Parameters.AddWithValue("NoPaciente", obj.oPaciente.NoPaciente);
                    cmd.Parameters.AddWithValue("Cintomas", obj.Cintomas);
                    cmd.Parameters.AddWithValue("IdEspecialista", obj.oEspecialista.IdEspecialista);
                    cmd.Parameters.AddWithValue("IdEnfermero", obj.oEnfermero.IdEnfermero);
                    cmd.Parameters.AddWithValue("PrecioCita", obj.PrecioCita);
                    cmd.Parameters.AddWithValue("IdEstado", obj.oEstado.IdEstado);
                    cmd.Parameters.AddWithValue("NoTurno", obj.NoTurno);


                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    //aqui modifique
                    //idautogenerado = cmd.Parameters["Referencia"].Value.ToString();
                    idautogenerado = cmd.Parameters["Resultado"].Value.ToString();
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (IOException ex)
            {
                idautogenerado = null;
                Mensaje = ex.Message;
            }
            return idautogenerado;
        }

        public bool Editar(Cita obj, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_Editar_Cita", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", obj.IdCita);
                    cmd.Parameters.AddWithValue("IdMedico", obj.oMedico.IdMedico);
                    cmd.Parameters.AddWithValue("NoPaciente", obj.oPaciente.NoPaciente);
                    cmd.Parameters.AddWithValue("Cintomas", obj.Cintomas);
                    cmd.Parameters.AddWithValue("IdEspecialista", obj.oEspecialista.IdEspecialista);
                    cmd.Parameters.AddWithValue("IdEnfermero", obj.oEnfermero.IdEnfermero);
                    cmd.Parameters.AddWithValue("PrecioCita", obj.PrecioCita);
                    cmd.Parameters.AddWithValue("IdEstado", obj.oEstado.IdEstado);

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

        public bool DarResultados(DarResultados obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_Dar_Resultados", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", obj.IdCita);
                    cmd.Parameters.AddWithValue("Resultados", obj.Resultados);
                

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

        public bool ActualizacionEstadoCita(ActualizarEstado obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_Actulizar_Estado_Cita", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", obj.IdCita);
                    cmd.Parameters.AddWithValue("IdEstado", obj.oEstado.IdEstado);


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


        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_Eliminar_Cita", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", id);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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
