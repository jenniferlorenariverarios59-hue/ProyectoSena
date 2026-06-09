using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoSena.Datos
{
    public class PlanInternoD
    {
        public int MtRegistrarPlanInterno(PlanInterno oPlanInterno)
        {
            int verificacion = 0;

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string consulta = $@"Sp_RegistrarPlanInterno";
                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaAsignacion", oPlanInterno.FechaAsignacion);
                    cmd.Parameters.AddWithValue("@FechaLimite", oPlanInterno.FechaLimite);
                    cmd.Parameters.AddWithValue("@ResultadosIncumplidos", oPlanInterno.ResultadosIncumplidos);
                    cmd.Parameters.AddWithValue("@EstadoPlan", oPlanInterno.EstadoPlan);
                    cmd.Parameters.AddWithValue("@EvaluacionProducto", oPlanInterno.EvaluacionProducto);
                    cmd.Parameters.AddWithValue("@EvaluacionConocimiento", oPlanInterno.EvaluacionConocimiento);
                    cmd.Parameters.AddWithValue("@EvaluacionDesempeno", oPlanInterno.EvaluacionDesempeno);
                    verificacion = cmd.ExecuteNonQuery();
                }
            }
            return verificacion;
        }


    }
}