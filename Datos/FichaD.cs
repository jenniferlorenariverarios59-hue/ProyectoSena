using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ProyectoSena.Datos
{
    public class FichaD
    {

        public List<Ficha> MtObtenerFicha(int IdAdmin)
        {
            List<Ficha> listaFicha = new List<Ficha>();

            using (SqlConnection   cn = ConexionDB.MtAbrirConexion())
            {

                cn.Open();

                string consulta = $@"Sp_ObtenerFichas";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd .CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdAdmin", IdAdmin);

                    DataTable dn = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dn);

                    foreach (DataRow item in dn.Rows)
                    {

                        Ficha oFicha = new Ficha();
                        oFicha.Id = Convert.ToInt32(item["Id"]);
                        oFicha.codigoFicha = item["CodigoFicha"].ToString();
                        oFicha.NombrePrograma = new Programa();

                        oFicha.NombrePrograma.Id = Convert.ToInt32(item["Id"]);
                        oFicha.NombrePrograma.CodigoPrograma = item["CodigoPrograma"].ToString() ;
                        oFicha.NombrePrograma.Nombre= item ["Nombre"].ToString() ;  
                        oFicha.NombrePrograma.Vesion = item["Version"].ToString () ;
                        oFicha.NombrePrograma.Nivel = item["Nivel"].ToString ();
                        oFicha.NombrePrograma.Duracion = item["Duracion"].ToString ( ) ;
                        oFicha.NombrePrograma.Estado = item["Estado"].ToString( ) ;

                        oFicha.FechaInicio = Convert.ToDateTime(item["FechaInicio"]);
                        oFicha.FechaFinalizacion = Convert.ToDateTime(item["FechaFinalizacion"]);
                        oFicha .Jornada =item["Jornada"].ToString( ) ;
                        oFicha.Descripcion= item ["Descripcion"].ToString( ) ;  
                        oFicha.Estado = item["Estado"].ToString();
                        listaFicha.Add(oFicha);
                        


                            


                    }


                }


            }

            return listaFicha;



        }

        public  int MtRegistrarFicha(Ficha  oFicha )
        {
            int Verificacion = 0;


            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string Consulta = $@"Insert  into  Ficha  values (@CodigoFicha,@FechaInicio ,@FechaFinalizacion,@Jornada,@Descripcion,@Estado, @IdPrograma)";

                using (SqlCommand cmd = new SqlCommand(Consulta, cn))
                {


                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodigoFicha", oFicha.codigoFicha);
                    cmd.Parameters.AddWithValue("@FechaInicio", oFicha.FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFinalizacion", oFicha.FechaFinalizacion);
                    cmd.Parameters.AddWithValue("@Jornada", oFicha.Jornada);
                    cmd.Parameters.AddWithValue("@Descripcion", oFicha.Descripcion);
                    cmd.Parameters.AddWithValue("@Estado",oFicha.Estado);
                    cmd.Parameters.AddWithValue("@IdPrograma", oFicha.NombrePrograma.Id);
                    Verificacion = cmd.ExecuteNonQuery();


                }
            }
            return Verificacion;

        } 

        public int MtEditarFicha(Ficha oFicha )
        {
            int Verificacion = 0;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string Consulta = $@"Update Ficha set CodigoFicha = @CodigoFicha, FechaInicio = @FechaInicio ,FechaFinalizacion=@FechaFinalizacion,Jornada =@Jornada,Descripcion=@Descripcion,Estado=@Estado, IdPrograma = @IdPrograma where Id = @Id";


                using (SqlCommand cmd = new SqlCommand(Consulta, cn))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", oFicha.Id);
                    cmd.Parameters.AddWithValue("@CodigoFicha", oFicha.codigoFicha);
                    cmd.Parameters.AddWithValue("@FechaInicio", oFicha.FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFinalizacion", oFicha.FechaFinalizacion);
                    cmd.Parameters.AddWithValue("@Jornada", oFicha.Jornada);
                    cmd.Parameters.AddWithValue("@Descripcion", oFicha.Descripcion);
                    cmd.Parameters.AddWithValue("@Estado", oFicha.Estado);
                    cmd.Parameters.AddWithValue("@IdPrograma", oFicha.NombrePrograma.Id);
                    Verificacion = cmd.ExecuteNonQuery();

                }
            }
            return Verificacion;
        }
         public int MtEliminarFicha(Ficha oficha)
        {

            int Verificacion =0;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn .Open();

                string Consulta = $@"Delete from Ficha Where Id =@Id";

                using (SqlCommand cmd = new SqlCommand(Consulta, cn))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("Id", oficha.Id);
                    Verificacion = cmd.ExecuteNonQuery();

                }

            }
            return Verificacion;    

        }
    }
}