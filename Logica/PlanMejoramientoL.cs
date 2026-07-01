using ProyectoSena.Datos;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace ProyectoSena.Logica
{
    public class PlanMejoramientoL
    {
        PlanMejoramientoD oPlanMejoramientoD = new PlanMejoramientoD();

        public int MtRegistrarPlanMejoramento(PlanMejoramientoM oPlanMejoramento)
        {

            int Verificacion = 0;

            Verificacion = oPlanMejoramientoD.MtRegistrarPlanMejoramiento(oPlanMejoramento);
            return Verificacion;



        }

        public List<PlanMejoramientoM> MtObtenerPlanMejoramiento(int IdInstructor)
        { 

            List<PlanMejoramientoM> listarPlanMejoramiento  = oPlanMejoramientoD.MtObtenerPlanMejoramiento(IdInstructor);
            return listarPlanMejoramiento;

        }
        public int EditarAprendiz(PlanMejoramientoM oPlanMejoramiento)
        {
            int Verificacion = oPlanMejoramientoD.MtEditarPlanMejoramiento(oPlanMejoramiento);
            return Verificacion;
        }


        public int MtEliminarPlanMejoramiento(PlanMejoramientoM oPanMejoramiento)
        {
            int Verificacion = oPlanMejoramientoD.MtEliminarPlanMejoramiento(oPanMejoramiento);
            return Verificacion;
        }


        public int MtEvaluacionPlan(PlanMejoramientoM oPlanMejoramiento)
        {

            int Verificacion = oPlanMejoramientoD.MtEvaluacionPlan(oPlanMejoramiento);
            return Verificacion;
        }

        public List<ResultadoAprendizaje> MtObtenerPendientesPorAprendiz(int IdAprendiz)
        {
            PlanMejoramientoD oPlanMejoramientoD = new PlanMejoramientoD();
            List<ResultadoAprendizaje> listaResultados = oPlanMejoramientoD.MtObtenerResultadospendientes(IdAprendiz);
            return listaResultados;
            
        }
    }
}

