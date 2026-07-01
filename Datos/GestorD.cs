  using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Web;

namespace ProyectoSena.Datos
{
    public class GestorD
    {
        public List<PlanMejoramientoM> MtObtenerPlanMejoramiento(int IdGestor)
        {

            List<PlanMejoramientoM> listarPlanMejoramiento = new List<PlanMejoramientoM>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {

                cn.Open();

                string consulta = $@"Sp_ObtenerPlanesGestor";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdGestor", IdGestor);

                    DataTable dn = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dn);

                    foreach (DataRow item in dn.Rows)
                    {

                        PlanMejoramientoM oPLanMejoramento = new PlanMejoramientoM();

                        oPLanMejoramento.Id = Convert.ToInt32(item["Id"]);
                        oPLanMejoramento.Instructor = new InstructorM();
                        oPLanMejoramento.Instructor.Nombre = item["NombreInstructor"].ToString();
                        oPLanMejoramento.Instructor.Apellido = item["ApellidoInstructor"].ToString();
                        oPLanMejoramento.Aprendiz = new AprendizM();
                        oPLanMejoramento.Aprendiz.Id = Convert.ToInt32(item["IdAprendiz"]);
                        oPLanMejoramento.Aprendiz.TipoDocumento = item["TipoDocumento"].ToString();
                        oPLanMejoramento.Aprendiz.NumeroDocumento = item["NumeroDocumento"].ToString();
                        oPLanMejoramento.Aprendiz.Nombre = item["NombreAprendiz"].ToString();
                        oPLanMejoramento.Aprendiz.Apellido = item["ApellidoAprendiz"].ToString();
                        oPLanMejoramento.PlanInternoComite = new PlanInterno();
                        oPLanMejoramento.PlanInternoComite.FechaAsignacion= Convert.ToDateTime(item["FechaInicio"]);
                        oPLanMejoramento.PlanInternoComite.FechaLimite = Convert.ToDateTime(item["FechaFinalizacion"]);
                        oPLanMejoramento.PlanInternoComite.EstadoPlan = item["Estado"].ToString();
                        listarPlanMejoramiento.Add(oPLanMejoramento);




                    }


                }

                return listarPlanMejoramiento;


            }

            
        }

        public int MtEditarPlanMejoramiento(GestorM oPlanMejoramiento)
        {


            int Verificacion = 0;

           


            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {

                String Consulta = "";

                using (SqlCommand cmd = new SqlCommand(Consulta, cn))
                {


                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("IdInstructor", oPlanMejoramiento.Id);
                    cmd.Parameters.AddWithValue("IdGestor", oPlanMejoramiento.Id);
                    Verificacion= cmd.ExecuteNonQuery();



                }
            }

            return Verificacion;   

        }

        

         public List<InstructorM>  MtObtenerInstructor(int IdGestor)
        {

            List<InstructorM > listarInstructor= new List<InstructorM>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = "";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))

                {


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdGestor", IdGestor);

                    DataTable dn = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dn);

                    foreach(DataRow item in  dn.Rows)
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
                return listarInstructor;
            }

        }
    }
}