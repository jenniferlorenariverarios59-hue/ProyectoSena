using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoSena.Datos
{
    public class AprendizFichasD
    {
        // metodos para el rol de aprendiz
        public List<Ficha> MtObtenerFichasAprendiz(int IdAprendiz)
        {
            List<Ficha> listaFichas = new List<Ficha>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = $@"Select * from Ficha f join FichaAprendiz fi on fi.IdFicha = f.Id join Programa p on f.IdPrograma = p.Id where fi.IdAprendiz = @IdAprendiz";
                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdAprendiz", IdAprendiz);

                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow item in dt.Rows)
                    {
                        Ficha oFicha = new Ficha();
                        oFicha.Id = Convert.ToInt32(item["Id"]);
                        oFicha.codigoFicha = item["CodigoFicha"].ToString();
                        oFicha.NombrePrograma = new Programa();

                        oFicha.NombrePrograma.Id = Convert.ToInt32(item["Id"]);
                        oFicha.NombrePrograma.CodigoPrograma = item["CodigoPrograma"].ToString();
                        oFicha.NombrePrograma.Nombre = item["Nombre"].ToString();
                        oFicha.NombrePrograma.Vesion = item["Version"].ToString();
                        oFicha.NombrePrograma.Nivel = item["Nivel"].ToString();
                        oFicha.NombrePrograma.Duracion = item["Duracion"].ToString();
                        oFicha.NombrePrograma.Estado = item["Estado"].ToString();

                        oFicha.FechaInicio = Convert.ToDateTime(item["FechaInicio"]);
                        oFicha.FechaFinalizacion = Convert.ToDateTime(item["FechaFinalizacion"]);
                        oFicha.Jornada = item["Jornada"].ToString();
                        oFicha.Descripcion = item["Descripcion"].ToString();
                        oFicha.Estado = item["Estado"].ToString();
                        listaFichas.Add(oFicha);
                    }
                }
            }return listaFichas;
        }

        public List<Observaciones> MtObtenerObservaciones (int IdAprendiz)
        {
            List<Observaciones> lsitaObservaciones = new List<Observaciones>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = $@"Select o.*, i.Nombre from Observacion o join PlanMejoramiento pm on pm.IdObservacion = o.Id join Instructor i on pm.IdInstructor = i.Id where pm.IdAprendiz = @IdAprendiz";
                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdAprendiz", IdAprendiz);

                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow item in dt.Rows)
                    {
                        Observaciones oObservacion = new Observaciones();
                        oObservacion.Nombre = item["Nombre"].ToString();
                        oObservacion.Descripcion = item["Descripcion"].ToString();
                        oObservacion.nombreInstructor = new InstructorM();
                        oObservacion.nombreInstructor.Nombre = item["Nombre"].ToString();
                        lsitaObservaciones.Add(oObservacion);
                    }
                }


            }return lsitaObservaciones;
        }

        public List<PlanMejoramientoM> MtObtenerPlanes(int IdAprendiz)
        {
            List<PlanMejoramientoM> listaPlanes = new List<PlanMejoramientoM>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = $@"Sp_ObtenerPlanes";
                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdAprendiz", IdAprendiz);

                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow item in dt.Rows)
                    {
                        PlanMejoramientoM oPlan = new PlanMejoramientoM();
                        oPlan.Id = Convert.ToInt32(item["Id"]);
                        oPlan.Aprendiz = new AprendizM();
                        oPlan.Aprendiz.Nombre = item["Aprendiz"].ToString();
                        oPlan.Instructor = new InstructorM();
                        oPlan.Instructor.Nombre =  item["Instructor"].ToString();
                        oPlan.PlanInternoComite = new PlanInterno();
                        oPlan.PlanInternoComite.FechaAsignacion = Convert.ToDateTime(item["FechaAsignacion"]);
                        oPlan.PlanInternoComite.FechaLimite = Convert.ToDateTime(item["FechaLimite"]);
                        oPlan.PlanInternoComite.EstadoPlan = item["EstadoPlan"].ToString();
                        oPlan.TipoPlan = item["TipoPlan"].ToString();
                        listaPlanes.Add(oPlan);
                    }
                }

            }return listaPlanes;
        }
        //metodos para el rol de instructor
        public List<AprendizM> MtObtenerAprendicesDeInstructor(int IdInstructor)
        {
            List<AprendizM> listaAprendices = new List<AprendizM>();

            using(SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = "Sp_ObtenerAprendicesPorInstructor";

                using(SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdInstructor", IdInstructor);

                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow item in dt.Rows)
                    {
                        AprendizM oAprendizM = new AprendizM();
                        oAprendizM.Id = Convert.ToInt32(item["Id"]);
                        oAprendizM.TipoDocumento = item["TipoDocumento"].ToString();
                        oAprendizM.NumeroDocumento = item["NumeroDocumento"].ToString();
                        oAprendizM.Nombre = item["Nombre"].ToString();
                        oAprendizM.Apellido = item["Apellido"].ToString();
                        oAprendizM.Correo = item["Correo"].ToString();
                        oAprendizM.Telefono = item["Telefono"].ToString();
                        oAprendizM.Ficha = new Ficha();
                        oAprendizM.Ficha.codigoFicha = item["codigoFicha"].ToString();
                        listaAprendices.Add(oAprendizM);
                    }
                }
            }
            return listaAprendices;
        }

    }
}