using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;

namespace ProyectoSena.Datos
{
    public class AprendizD
    {
        public List<AprendizM> MtObtenerAprendiz(int IdAdmin)
        {
            List<AprendizM> listarAprendices = new List<AprendizM>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = @"Select * from Aprendiz ap join FichaAprendiz fa on fa.IdAprendiz = ap.Id join Ficha f on fa.IdFicha =f.Id join Programa p on f.IdPrograma = p.Id join CentroFormacion cf on p.IdCentroFormacion = cf.Id join Administrador a on a.IdCentroFormacion = cf.Id where a.Id = @IdAdmin";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdAdmin", IdAdmin);

                    DataTable cd = new DataTable();

                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(cd);

                    foreach (DataRow item in cd.Rows)
                    {

                        AprendizM oApendicez = new AprendizM();

                        oApendicez.Id = Convert.ToInt32(item["Id"]);
                        oApendicez.TipoDocumento = item["TipoDocumento"].ToString();
                        oApendicez.NumeroDocumento = item["NumeroDocumento"].ToString();
                        oApendicez.Nombre = item["Nombre"].ToString();
                        oApendicez.Apellido = item["Apellido"].ToString();
                        oApendicez.Correo = item["Correo"].ToString();
                        oApendicez.Telefono = item["Telefono"].ToString();




                        oApendicez.Ficha = new Ficha();
                        oApendicez.Ficha.Id = Convert.ToInt32(item["Id"]);
                        oApendicez.Ficha.codigoFicha = item["CodigoFicha"].ToString();
                        oApendicez.Ficha.NombrePrograma = new Programa();
                        oApendicez.Ficha.NombrePrograma.Nombre = item["Nombre"].ToString();
                        listarAprendices.Add(oApendicez);

                    }

                }

            }
            return listarAprendices;

        }

        public int MtRegistrarAprendiz(AprendizM oAprendiz)
        {
            int verificacion = 0;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {

                cn.Open();

                string consulta = @"Insert into Aprendiz values (@TipoDocumento, @NumeroDocumento ,@Nombre ,@Apellido ,@Correo, @Contraseña ,@Telefono, 2)";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))

                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TipoDocumento ", oAprendiz.TipoDocumento);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", oAprendiz.NumeroDocumento);
                    cmd.Parameters.AddWithValue("@Nombre ", oAprendiz.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido ", oAprendiz.Apellido);
                    cmd.Parameters.AddWithValue("@Correo", oAprendiz.Correo);
                    cmd.Parameters.AddWithValue("@Contraseña", oAprendiz.Contraseña);
                    cmd.Parameters.AddWithValue("@Telefono", oAprendiz.Telefono);
                    cmd.Parameters.AddWithValue("@Ficha", oAprendiz.Ficha.Id);

                }


            }

            return verificacion;

        }

        public int MtEditarAprendiz(AprendizM oAprendiz)
        {
            int verificacion = 0;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {


                cn.Open();

                string consulta = @"Update Aprendiz set TipoDocumento  = @TipoDocumento , NumeroDocumento = @NumeroDocumento , Nombre  = @Nombre , Apellido  = @Apellido, Correo = @Correo , Telefono  = @Telefono  where Id = @Id";



                using (SqlCommand cmd = new SqlCommand(consulta,cn))
                {
                    

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", oAprendiz.Id);
                    cmd.Parameters.AddWithValue("@TipoDocumento", oAprendiz.TipoDocumento);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", oAprendiz.NumeroDocumento);
                    cmd.Parameters.AddWithValue("@Nombre", oAprendiz.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", oAprendiz.Apellido);
                    cmd.Parameters.AddWithValue("@Correo", oAprendiz.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", oAprendiz.Telefono);
                    cmd.Parameters.AddWithValue("@Ficha", oAprendiz.Ficha.Id);
                    verificacion = cmd.ExecuteNonQuery();
                }

            }

            return verificacion;
        }

        public int MtEliminarAprendiz( AprendizM oAprendiz) 
        
        {
            int verificacion = 0;

            using(SqlConnection  cn  = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = $@"Sp_EliminarAprendiz";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", oAprendiz.Id);
                    verificacion= cmd.ExecuteNonQuery();
                }
            }

            return verificacion;
        }
    }
}
 
