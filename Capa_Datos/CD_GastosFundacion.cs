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
  public  class CD_GastosFundacion 
    {
        public List<GastosFundacion> Listar()
        {
            List<GastosFundacion> lista = new List<GastosFundacion>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("Select gf.NoGasto,f.IdFundacion, f.Nombre[Fundacion],");
                    sb.AppendLine("g.IdGasto,g.Nombre[Gasto],g.Monto,g.Descripcion,gf.FechaRegistro");
                    sb.AppendLine("from GastoFundacion gf ");
                    sb.AppendLine("inner join Fundacion f on f.IdFundacion = gf.IdFundacion");
                    sb.AppendLine("Inner join Gasto g on g.IdGasto = gf.IdGasto");
                    sb.AppendLine("order by  gf.NoGasto desc");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new GastosFundacion()
                            {
                                NoGasto = Convert.ToInt32(dr["NoGasto"]),
                                oFundacion = new Fundacion() { IdFundacion = Convert.ToInt32(dr["IdFundacion"]), Nombre = dr["Fundacion"].ToString() },

                                oGastos = new Gastos()
                                {
                                    IdGasto = Convert.ToInt32(dr["IdGasto"]),
                                    Nombre = dr["Gasto"].ToString()
                                },
                                Monto = Convert.ToDecimal(dr["Monto"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                 FechaRegistro = dr["FechaRegistro"].ToString()

                            }
                            );
                        }
                    }

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                lista = new List<GastosFundacion>();
            }

            return lista;
        }

        public string Registrar(GastosFundacion obj, out string Mensaje)
        {
            string idautogenerado = null;

            Mensaje = string.Empty;
            try
            {


                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_Registrar_GastosFundacion", oconexion);

                    cmd.Parameters.AddWithValue("IdFundacion", obj.oFundacion.IdFundacion);
                    cmd.Parameters.AddWithValue("IdGasto", obj.oGastos.IdGasto);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idautogenerado = cmd.Parameters["Resultado"].Value.ToString();
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idautogenerado = null;
                Mensaje = ex.Message;
            }
            return idautogenerado;
        }


        public bool Editar(GastosFundacion obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_Editar_GastosFundacion", oconexion);
                    cmd.Parameters.AddWithValue("NoGasto", obj.NoGasto);
                    cmd.Parameters.AddWithValue("IdFundacion", obj.oFundacion.IdFundacion);
                    cmd.Parameters.AddWithValue("IdGasto", obj.oGastos.IdGasto);

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
                    SqlCommand cmd = new SqlCommand("sp_Eliminar_GastoFundacion", oconexion);
                    cmd.Parameters.AddWithValue("NoGasto", id);
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