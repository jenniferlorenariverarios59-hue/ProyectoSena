using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoSena.Datos
{
    public class ProgramaD
    {
        public List<Programa> MtObtenerProgramas(int IdAdmin)
        {
            List<Programa> listaProgramas = new List<Programa>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = @"Sp_ObtenerProgramas";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdAdmin", IdAdmin);

                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow item in dt.Rows)
                    {
                        Programa oPrograma = new Programa();
                        oPrograma.Id = Convert.ToInt32(item["Id"]);
                        oPrograma.CodigoPrograma = item["CodigoPrograma"].ToString();
                        oPrograma.Nombre = item["Nombre"].ToString();
                        oPrograma.Vesion = item["Version"].ToString();
                        oPrograma.Nivel = item["Nivel"].ToString();
                        oPrograma.Duracion = item["Duracion"].ToString();
                        oPrograma.Estado = item["Estado"].ToString();
                        listaProgramas.Add(oPrograma);

                    }

                }
            }
            return listaProgramas;
        }
        public int MtRegistrarPrograma(Programa oPrograma)
        {
            int verificacion = 0;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = "Sp_CrearPrograma";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodigoPrograma", oPrograma.CodigoPrograma);
                    cmd.Parameters.AddWithValue("@Nombre", oPrograma.Nombre);
                    cmd.Parameters.AddWithValue("@Version", oPrograma.Vesion);
                    cmd.Parameters.AddWithValue("@Nivel", oPrograma.Nivel);
                    cmd.Parameters.AddWithValue("@Duracion", oPrograma.Duracion);
                    cmd.Parameters.AddWithValue("@Estado", oPrograma.Estado);
                    cmd.Parameters.AddWithValue("@IdAdmin", oPrograma.IdAdmin);
                    verificacion = cmd.ExecuteNonQuery();

                }
            }
            return verificacion;
        }

        public int MtEditarProgramas(Programa oPrograma)
        {
            int verificacion = 0;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = $@" Update Programa set CodigoPrograma = @CodigoPrograma, Nombre = @Nombre, Version = @Version, Nivel = @Nivel, Duracion = @Duracion, Estado = @Estado where Id = @Id";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", oPrograma.Id);
                    cmd.Parameters.AddWithValue("@CodigoPrograma", oPrograma.CodigoPrograma);
                    cmd.Parameters.AddWithValue("@Nombre", oPrograma.Nombre);
                    cmd.Parameters.AddWithValue("@Version", oPrograma.Vesion);
                    cmd.Parameters.AddWithValue("@Nivel", oPrograma.Nivel);
                    cmd.Parameters.AddWithValue("@Duracion", oPrograma.Duracion);
                    cmd.Parameters.AddWithValue("@Estado", oPrograma.Estado);
                    verificacion = cmd.ExecuteNonQuery();

                }
            }
            return verificacion;

        }

        public int MtEliminarPrograma(Programa oPrograma)
        {
            int verificacion = 0;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = $@"Sp_EliminarPrograma";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPrograma", oPrograma.Id);
                    verificacion = cmd.ExecuteNonQuery();
                }
            }
            return verificacion;
        }
    }

}

