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
        public List<PlanMejoramientoM> MtObtenerPlanMejoramiento(int IdInstructor)
        {

            List<PlanMejoramientoM> listarPlanMejoramiento  = new List<PlanMejoramientoM>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {

                cn.Open();

                string consulta = $@"Sp_ObtenerPlanes";

                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdInstructor", IdInstructor);

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
                        oPLanMejoramento.PlanInternoComite.FechaAsignacion = Convert.ToDateTime(item["FechaAsignacion"]);
                        oPLanMejoramento.PlanInternoComite.FechaLimite = Convert.ToDateTime(item["FechaLimite"]);
                        oPLanMejoramento.PlanInternoComite.EstadoPlan= item["EstadoPlan"].ToString() ;
                        listarPlanMejoramiento.Add(oPLanMejoramento);




                    }


                }

                return listarPlanMejoramiento;


            }
        }
        public int MtRegistrarPlanMejoramiento(PlanMejoramientoM oPlanMejoramiento)
        {
            int verificacion = 0;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = $@"Insert into PlanInterno (FechaAsignacion, FechaLimite, EstadoPlan) values (@FechaAsignacion, @FechaLimite, @EstadoPlan); Select SCOPE_IDENTITY();";
                string consulta5 = $@"Insert Into Observacion (Nombre ,Descripcion ) values (@Nombre ,@Descrpcion );Select SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@FechaAsignacion", oPlanMejoramiento.PlanInternoComite.FechaAsignacion);
                    cmd.Parameters.AddWithValue("@FechaLimite", oPlanMejoramiento.PlanInternoComite.FechaLimite);
                    cmd.Parameters.AddWithValue("@EstadoPlan", oPlanMejoramiento.PlanInternoComite.EstadoPlan);
                    int IdPlanInterno = Convert.ToInt32(cmd.ExecuteScalar());

                    int IdObservaciones = 0;
                    using (SqlCommand cmd5 = new SqlCommand(consulta5, cn))
                    {
                        cmd5.CommandType = CommandType.Text;
                        cmd5.Parameters.AddWithValue("@Nombre", oPlanMejoramiento.Observacion.Nombre);
                        cmd5.Parameters.AddWithValue("@Descripcion", oPlanMejoramiento.Observacion.Descripcion);
                        IdObservaciones =Convert.ToInt32(cmd5.ExecuteScalar());
                     }


                        List<int> listaIdActividad = new List<int>();

                    foreach (var item in oPlanMejoramiento.ActividadPropuesta)
                    {
                        string consulta2 = "Insert into Actividad values (@Nombre, @Descripcion); select SCOPE_IDENTITY();";

                        SqlCommand cmd2 = new SqlCommand(consulta2, cn);
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Parameters.AddWithValue("@Nombre", item.Nombre);
                        cmd2.Parameters.AddWithValue("@Descripcion", item.Descripcion);

                        int IdActividad = Convert.ToInt32(cmd2.ExecuteScalar());
                        listaIdActividad.Add(IdActividad);
                    }
                    

                    List<int> listaIdPlanMejoramiento = new List<int>();
                    int IdPlanMejoramiento = 0;

                    foreach (var item in listaIdActividad)
                    {
                        string consulta3 = "Insert into PlanMejoramiento (IdPlanInterno, IdAprendiz, IdActividad, IdInstructor,IdObservacion) values (@IdPlanInterno, @IdAprendiz, @IdActividad, @IdInstructor,@IdObservacion); select SCOPE_IDENTITY();";

                        SqlCommand cmd3 = new SqlCommand(consulta3, cn);
                        cmd3.CommandType = CommandType.Text;
                        cmd3.Parameters.AddWithValue("@IdPlanInterno", IdPlanInterno);
                        cmd3.Parameters.AddWithValue("@IdAprendiz", oPlanMejoramiento.Aprendiz.Id);
                        cmd3.Parameters.AddWithValue("@IdActividad", item);
                        cmd3.Parameters.AddWithValue("@IdInstructor", oPlanMejoramiento.Instructor.Id);
                        cmd3.Parameters.AddWithValue("@IdObservacion", IdObservaciones);
                        IdPlanMejoramiento = Convert.ToInt32(cmd3.ExecuteScalar());
                        listaIdPlanMejoramiento.Add(IdPlanMejoramiento);
                    }

                    foreach (var item in oPlanMejoramiento.ResultadosIncumplidos)
                    {
                        string consulta4 = "Insert into PlanMejoramientoResultado values (@IdPlanMejoramiento, @IdResultadoAprendiz);";

                        SqlCommand cmd4 = new SqlCommand(consulta4, cn);
                        cmd4.CommandType = CommandType.Text;
                        cmd4.Parameters.AddWithValue("@IdPlanMejoramiento", IdPlanMejoramiento);
                        cmd4.Parameters.AddWithValue("@IdResultadoAprendiz", item);
                        verificacion = cmd4.ExecuteNonQuery();
                    }

                }
            }
            return verificacion;
        }
        

        

        public int MtEditarPlanMejoramiento(PlanMejoramientoM oPlanMejoramiento)
        {
            int Verificacion = 0;

            string Consulta = $@"Update PlanMejoramento set instructor =@Instructor, Aprendiz =@Aprendiz, NombreActividad =@NombreActividad ,
                             Descripcion=@Descripcon, FechaAsignacion =@FehaAsignacion,
                             EvaluacionDesempeno=@EvaluacionDesempeno, Id@IdInstructor=@@IdInstructor where Id = @Id";


                

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(Consulta ,cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdInstructor", oPlanMejoramiento.Instructor.Id);
                    cmd.Parameters.AddWithValue("@IdAprendiz", oPlanMejoramiento.Aprendiz.Id);


                    cmd.Parameters.AddWithValue("@FechaAsignacion", oPlanMejoramiento.PlanInternoComite.FechaAsignacion);
                    cmd.Parameters.AddWithValue("@FechaLimite", oPlanMejoramiento.PlanInternoComite.FechaLimite);
                    cmd.Parameters.AddWithValue("@ResultadosIncumplidos", oPlanMejoramiento.PlanInternoComite.ResultadosIncumplidos);
                    cmd.Parameters.AddWithValue("@EstadoPlan", oPlanMejoramiento.PlanInternoComite.EstadoPlan);
                    Verificacion = cmd.ExecuteNonQuery();


                }
            }
            return Verificacion;


        }


        public int MtEliminarPlanMejoramiento(PlanMejoramientoM oPlanMejoramiento)
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


        public int MtEvaluacionPlan(PlanMejoramientoM oPlanMejoramiento)
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

        public List<ResultadoAprendizaje> MtObtenerResultadospendientes(int IdAprendiz)
        {
            List<ResultadoAprendizaje> listaResultados = new List<ResultadoAprendizaje> ();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open ();

                string consulta = "SELECT * FROM Resultado r JOIN ResultadoAprendiz ra ON r.Id = ra.IdResultado WHERE ra.IdAprendiz = @IdAprendiz AND r.Estado = 'Pendiente'";

                using(SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdAprendiz", IdAprendiz);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        ResultadoAprendizaje oResultado = new ResultadoAprendizaje ();
                        oResultado.Id = Convert.ToInt32 (dr["Id"]);
                        oResultado.Nombre = dr["Nombre"].ToString();
                        oResultado.Estado = dr["Estado"].ToString();
                        listaResultados.Add (oResultado);
                    }
                }
            }
            return listaResultados;
        }
    }
    

}





