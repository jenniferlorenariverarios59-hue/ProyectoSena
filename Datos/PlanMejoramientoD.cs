using ProyectoSena.Modelo;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace ProyectoSena.Datos
{
    public class PlanMejoramientoD


    {
        public List<PlanMejoramiento> MtObtenerPlanMejoramiento(int IdInstructor)
        {

            List<PlanMejoramiento> listarPlanMejoramiento  = new List<PlanMejoramiento>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {

                cn.Open();

                string consulta = $@"Sp_ObtenerPlanes";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    

                    DataTable dn = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dn);

                    foreach (DataRow item in dn.Rows)
                    {

                        PlanMejoramiento oPLanMejoramento = new PlanMejoramiento();

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
                        oPLanMejoramento.Aprendiz.Ficha = new Ficha();
                        oPLanMejoramento.Aprendiz.Ficha.codigoFicha = item["CodigoFicha"].ToString();
                        oPLanMejoramento.Aprendiz.Ficha.NombrePrograma = new Programa();
                        oPLanMejoramento.Aprendiz.Ficha.NombrePrograma.Nombre = item["NombrePrograma"].ToString();
                        oPLanMejoramento.PlanInternoComite = new PlanInterno();
                        oPLanMejoramento.PlanInternoComite.FechaAsignacion = Convert.ToDateTime(item["FechaAsignacion"]);
                        oPLanMejoramento.PlanInternoComite.FechaLimite = Convert.ToDateTime(item["FechaLimte"]);
                        oPLanMejoramento.PlanInternoComite.EstadoPlan= item["EstadoPlan"].ToString() ;





                    }


                }

                return listarPlanMejoramiento;


            }
        }
        public int MtRegistrarPlanMejoramiento(PlanMejoramiento oPlanMejoramiento)
        {
            int verificacion = 0;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = $@"Sp_RegistrarPlanMejoramiento";
                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdInstructor", oPlanMejoramiento.Instructor.Id);
                    cmd.Parameters.AddWithValue("@IdAprendiz", oPlanMejoramiento.Aprendiz.Id);
                    cmd.Parameters.AddWithValue("@NombreActividad", oPlanMejoramiento.ActividadPropuesta.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", oPlanMejoramiento.ActividadPropuesta.Descripcion);


                    cmd.Parameters.AddWithValue("@FechaAsignacion", oPlanMejoramiento.PlanInternoComite.FechaAsignacion);
                    cmd.Parameters.AddWithValue("@FechaLimite", oPlanMejoramiento.PlanInternoComite.FechaLimite);
                    cmd.Parameters.AddWithValue("@ResultadosIncumplidos", oPlanMejoramiento.PlanInternoComite.ResultadosIncumplidos);
                    cmd.Parameters.AddWithValue("@EstadoPlan", oPlanMejoramiento.PlanInternoComite.EstadoPlan);
                    verificacion = cmd.ExecuteNonQuery();

                }
            }
            return verificacion;
        }
        

        

        public int MtEditarPlanMejoramiento(PlanMejoramiento oPlanMejoramiento)
        {
            int Verificacion = 0;

            string Consulta = $@"Update PlanMejoramento set instructor =@Instructor, Aprendiz =@Aprendiz, NombreActividad =@NombreActividad ,
                             Descripcion=@Descripcon, FechaAsignacion =@FehaAsignacion,
                             EvaluacionDesempeno=@EvaluacionDesempeno, Id@IdInstructor=@@IdInstructor where Id = @Id";




            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdInstructor", oPlanMejoramiento.Instructor.Id);
                    cmd.Parameters.AddWithValue("@IdAprendiz", oPlanMejoramiento.Aprendiz.Id);
                    cmd.Parameters.AddWithValue("@NombreActividad", oPlanMejoramiento.ActividadPropuesta.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", oPlanMejoramiento.ActividadPropuesta.Descripcion);


                    cmd.Parameters.AddWithValue("@FechaAsignacion", oPlanMejoramiento.PlanInternoComite.FechaAsignacion);
                    cmd.Parameters.AddWithValue("@FechaLimite", oPlanMejoramiento.PlanInternoComite.FechaLimite);
                    cmd.Parameters.AddWithValue("@ResultadosIncumplidos", oPlanMejoramiento.PlanInternoComite.ResultadosIncumplidos);
                    cmd.Parameters.AddWithValue("@EstadoPlan", oPlanMejoramiento.PlanInternoComite.EstadoPlan);
                    Verificacion = cmd.ExecuteNonQuery();


                }
            }
            return Verificacion;


        }


        public int MtEliminarPlanMejoramiento(PlanMejoramiento oPlanMejoramiento)
        {

            int Verificacion = 0;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string Consulta = $@"Delete from Ficha Where Id =@Id";

                using (SqlCommand cmd = new SqlCommand(Consulta, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("Id", oPlanMejoramiento.PlanInternoComite.Id);
                    Verificacion = cmd.ExecuteNonQuery();

                }
            }
            return Verificacion;

        }


        public int MtEvaluacionPlan(PlanMejoramiento oPlanMejoramiento)
        {
            int Verificacion = 0;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {

                cn.Open();

                string Consulta = "";

                using (SqlCommand cmd = new SqlCommand(Consulta ,cn ))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", oPlanMejoramiento.PlanInternoComite.Id);
                    cmd.Parameters.AddWithValue("@EvaluacionProducto", oPlanMejoramiento.PlanInternoComite.EvaluacionProducto);
                    cmd.Parameters.AddWithValue("@EvaluacionConocimiento", oPlanMejoramiento.PlanInternoComite.EvaluacionConocimiento);
                    cmd.Parameters.AddWithValue("@EvaluacionDesempe", oPlanMejoramiento.PlanInternoComite.EvaluacionDesempeno);
                    cmd.Parameters.AddWithValue("@ObservacionesNombre", oPlanMejoramiento.Observacion.Nombre);
                    cmd.Parameters.AddWithValue("@ObservacionDescripcion", oPlanMejoramiento.Observacion.Descripcion);
                    Verificacion = cmd.ExecuteNonQuery();

                    

                }



            }
            return Verificacion;
        }
    }
    

}





