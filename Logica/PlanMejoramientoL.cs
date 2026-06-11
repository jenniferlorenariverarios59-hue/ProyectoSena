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

        public int MtRegistrarPlanMejoramento(PlanMejoramiento oPlanMejoramento)
        {

            int Verificacion = 0;

            Verificacion = oPlanMejoramientoD.MtRegistrarPlanMejoramiento(oPlanMejoramento);
            return Verificacion;



        }

        public List<PlanMejoramiento> MtObtenerPlanMejoramiento(int IdInstructor)
        { 

            List<PlanMejoramiento> listarPlanMejoramiento  = oPlanMejoramientoD.MtObtenerPlanMejoramiento(IdInstructor);
            return listarPlanMejoramiento;

        }
        public int EditarAprendiz(PlanMejoramiento oPlanMejoramiento)
        {
            int Verificacion = oPlanMejoramientoD.MtEditarPlanMejoramiento(oPlanMejoramiento);
            return Verificacion;
        }


        public int MtEliminarPlanMejoramiento(PlanMejoramiento oPanMejoramiento)
        {
            int Verificacion = oPlanMejoramientoD.MtEliminarPlanMejoramiento(oPanMejoramiento);
            return Verificacion;
        }


        public int MtEvaluacionPlan(PlanMejoramiento oPlanMejoramiento)
        {

            int Verificacion = oPlanMejoramientoD.MtEvaluacionPlan(oPlanMejoramiento);
            return Verificacion;
        }


    }
}

