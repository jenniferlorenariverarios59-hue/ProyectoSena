using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoSena.Datos
{
    public class PlanComiteD
    {
        public int MtRegistrarPlanComite(PlanComite oPlanComite)
        {
            int verificacion = 0;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = $@"Sp_RegistrarPlanComite";
                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaAsignacion", oPlanComite.FechaAsignacion);
                    cmd.Parameters.AddWithValue("@FechaLimite", oPlanComite.FechaLimite);
                    cmd.Parameters.AddWithValue("@ResultadosIncumplidos", oPlanComite.ResultadosIncumplidos);
                    cmd.Parameters.AddWithValue("@EstadoPlan", oPlanComite.EstadoPlan);
                    cmd.Parameters.AddWithValue("@EvaluacionProducto", oPlanComite.EvaluacionProducto);
                    cmd.Parameters.AddWithValue("@EvaluacionConocimiento", oPlanComite.EvaluacionConocimiento);
                    cmd.Parameters.AddWithValue("@EvaluacionDesempeno", oPlanComite.EvaluacionDesempeno);
                    verificacion = cmd.ExecuteNonQuery();
                }
            }
            return verificacion;
        }
    }
}