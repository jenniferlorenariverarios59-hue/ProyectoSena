using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace ProyectoSena.Datos
{
    public class InstructorD
    {

        public List<InstructorM> MtObtenerInstructor(int IdAdmin)
        {
            List<InstructorM> listarInstructor = new List<InstructorM>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = $@"Select i.* from Instructor i join FichaIntructor fi on fi.IdInstructor = i.Id join Ficha f on fi.IdFicha = f.Id join Programa p on f.IdPrograma = p.Id join CentroFormacion cf on p.IdCentroFormacion = cf.Id join Administrador a on a.IdCentroFormacion = cf.Id where a.Id = @IdAdmin";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdAdmin", IdAdmin);

                    DataTable cd = new DataTable();

                    SqlDataAdapter dt = new SqlDataAdapter(cmd);
                    dt.Fill(cd);

                    foreach (DataRow item in cd.Rows)
                    {
                        InstructorM oInstructor = new InstructorM();
                        oInstructor.Id = Convert.ToInt32(item["Id"]);
                        oInstructor.TipoDocumento = item["TipoDocumento"].ToString();
                        oInstructor.NumeroDocumento = item["NumeroDocumento"].ToString();
                        oInstructor.Nombre = item["Nombre"].ToString();
                        oInstructor.Apellido = item["Apellido"].ToString();
                        oInstructor.Correo = item["Correo"].ToString();
                        oInstructor.Telefono = item["Telefono"].ToString();
                        oInstructor.Especialidad = item["Especialidad"].ToString();
                        listarInstructor.Add(oInstructor);
                    }

                }
                

            }
            return listarInstructor;
        }
        public int MtRegistrarInstructor(InstructorM oInstrutor)
        {
            int Verificacion = 0;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn .Open();

                string consulta = $@"Sp_CrearInstructor";

                using (SqlCommand cmd =  new SqlCommand(consulta, cn))
                {
                   
                    cmd .CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoDocumento", oInstrutor.TipoDocumento);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", oInstrutor.NumeroDocumento);
                    cmd.Parameters.AddWithValue("@Nombre", oInstrutor.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", oInstrutor.Apellido);
                    cmd.Parameters.AddWithValue("@Correo", oInstrutor.Correo);
                    cmd.Parameters.AddWithValue("@Contraseña", oInstrutor.Contraseña);
                    cmd.Parameters.AddWithValue("@Telefono", oInstrutor.Telefono);
                    cmd.Parameters.AddWithValue("@Especialidad", oInstrutor.Especialidad);
                    cmd.Parameters.AddWithValue("@IdFicha", oInstrutor.IdFicha);
                    Verificacion= cmd.ExecuteNonQuery();

                }
            }
            return Verificacion;
        }
        public int MtEditarInstructor(InstructorM oInstructor )
        {
            int Verificacion = 0;

            using(SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn .Open();

               
                string Consulta = $@"Sp_ActualizarInstructor";

                using (SqlCommand cmd = new SqlCommand(Consulta, cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdInstructor", oInstructor.Id);
                    cmd.Parameters.AddWithValue("@TipoDocumento", oInstructor.TipoDocumento);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", oInstructor.NumeroDocumento);
                    cmd.Parameters.AddWithValue("@Nombre", oInstructor.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", oInstructor.Apellido);
                    cmd.Parameters.AddWithValue("@Correo", oInstructor.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", oInstructor.Telefono);
                    cmd.Parameters.AddWithValue("@Especialidad", oInstructor.Especialidad);
                    cmd.Parameters.AddWithValue("@IdFicha", oInstructor.IdFicha);
                    Verificacion= cmd.ExecuteNonQuery();



                }


            }

            return Verificacion;

        }

        public int MtEliminarInstructor(InstructorM oInstructor)
        {
            int Verificacion = 0;

            string Consulta = $@"Sp_EliminarInstructor";

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn .Open();

                using (SqlCommand cmd =  new SqlCommand(Consulta, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", oInstructor.Id);
                    Verificacion= cmd.ExecuteNonQuery();


                }

            }

            return Verificacion;    


        }
    }
}
