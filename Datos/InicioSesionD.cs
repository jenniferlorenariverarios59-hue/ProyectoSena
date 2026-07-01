using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using ProyectoSena.Vista;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoSena.Datos
{
    public class InicioSesionD
    {

        public AprendizM MtInicioAprendiz(InicioSesion oInicioSesion) 

        {
            AprendizM oAprendiz = null;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();
                string Consulta = @"Select * from Aprendiz a join FichaAprendiz fa on fa.IdAprendiz = a.Id join Ficha f on fa.IdFicha = f.Id join Programa p on f.IdPrograma = p.Id  Where Correo =@Correo  and Contraseña= @Contraseña ";
                using (SqlCommand cmd = new SqlCommand(Consulta, cn))
                {
                   cmd.CommandType =   CommandType.Text;
                    cmd.Parameters.AddWithValue("@Rol", oInicioSesion.Rol);
                    cmd.Parameters.AddWithValue("@Correo", oInicioSesion.Correo);
                    cmd.Parameters.AddWithValue("@Contraseña", oInicioSesion.Contraseña);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        oAprendiz = new AprendizM();
                        oAprendiz.Id = Convert.ToInt32(dr["Id"]);
                        oAprendiz.TipoDocumento = dr["TipoDocumento"].ToString();
                        oAprendiz.NumeroDocumento = dr["NumeroDocumento"].ToString();
                        oAprendiz.Nombre = dr["Nombre"].ToString();
                        oAprendiz.Apellido = dr ["Apellido"].ToString();
                        oAprendiz.Correo = dr["Correo"].ToString() ;
                        oAprendiz.Telefono = dr["Telefono"].ToString ();
                        oAprendiz.Ficha = new Ficha();
                        oAprendiz.Ficha.codigoFicha = dr["CodigoFicha"].ToString();
                        oAprendiz.Ficha.NombrePrograma = new Programa();
                        oAprendiz.Ficha.NombrePrograma.Nombre = dr["Nombre"].ToString();

                    }
                    
                }
            }
            return oAprendiz;



        }
        public InstructorM MtInicioInstructor(InicioSesion oInicioSesion)
        {

            InstructorM oInstructor = null;



            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();
                string Consulta = @"Select * from Instructor Where Correo =@Correo  and Contraseña= @Contraseña ";
                using (SqlCommand cmd = new SqlCommand(Consulta, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Rol", oInicioSesion.Rol);
                    cmd.Parameters.AddWithValue("@Correo", oInicioSesion.Correo);
                    cmd.Parameters.AddWithValue("@Contraseña", oInicioSesion.Contraseña);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        oInstructor = new InstructorM();
                        oInstructor.Id = Convert.ToInt32(dr["Id"]);
                        oInstructor.TipoDocumento = dr["TipoDocumento"].ToString();
                        oInstructor .NumeroDocumento = dr["NumeroDocumento"].ToString();
                        oInstructor .Nombre = dr["Nombre"].ToString();
                        oInstructor .Apellido = dr["Apellido"].ToString();
                        oInstructor .Correo = dr["Correo"].ToString();
                        oInstructor .Telefono = dr["Telefono"].ToString();
                        oInstructor .Especialidad  = dr["Especialidad"].ToString();



                    }

                }
            }
           return oInstructor;
        }

        public AdministradorM MtInicioAdministrador(InicioSesion oInicioSesion) 
        {

            AdministradorM oAdministrador = null;


            using ( SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();
                string Consulta = @"Select * from Administrador a Where a.Correo = @Correo  and a.Contraseña = @Contraseña ";
                using (SqlCommand cmd = new SqlCommand(Consulta, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Rol", oInicioSesion.Rol);
                    cmd.Parameters.AddWithValue("@Correo", oInicioSesion.Correo);
                    cmd.Parameters.AddWithValue("@Contraseña", oInicioSesion.Contraseña);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            oAdministrador = new AdministradorM();
                            oAdministrador.Id = Convert.ToInt32(dr["Id"]);
                            oAdministrador.TipoDocumento = dr["TipoDocumeto"].ToString();
                            oAdministrador.NumeroDocumento = dr["NumeroDocumento"].ToString();
                            oAdministrador.Nombre = dr["Nombre"].ToString();
                            oAdministrador.Apellido = dr["Apellido"].ToString();
                            oAdministrador.Correo = dr["Correo"].ToString();
                            oAdministrador.Telefono = dr["Telefono"].ToString();

                            oAdministrador.IdCentro = Convert.ToInt32(dr["IdCentroFormacion"]);
                            oAdministrador.NombreCentro = dr["Nombre"].ToString();
                        }
                    }
                }
            }
            return oAdministrador;





        }


        public GestorM MtInicioGestor( InicioSesion oInicioSesion)
        {
            GestorM oGestor = null;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string Consulta = "Select * from Gestor Where  Correo =@Correo  and Contraseña =@Contraseña";

                using (SqlCommand cmd = new SqlCommand(Consulta, cn))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@RoL", oInicioSesion.Rol);
                    cmd.Parameters.AddWithValue("@Correo", oInicioSesion.Correo);
                    cmd.Parameters.AddWithValue("@Contraseña", oInicioSesion.Contraseña);


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            oGestor = new GestorM();
                            oGestor.Id = Convert.ToInt32(dr["Id"]);
                            oGestor.TipoDocumento = dr["TipoDocumento"].ToString();
                            oGestor.NumeroDocumento = dr["NumeroDocumeto"].ToString();
                            oGestor.Nombre = dr["Nombre"].ToString();
                            oGestor.Apellido = dr["Apellido"].ToString();
                            oGestor.Correo = dr["Correo"].ToString();
                        } 


                    }


                }

                return oGestor;

            }
        }




    }
}