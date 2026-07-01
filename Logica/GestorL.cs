using ProyectoSena.Datos;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSena.Logica
{
    public class GestorL
    {

        GestorD oGestorD = new GestorD();
        public List<PlanMejoramientoM> MtObtenerPlanMejoramiento(int IdGestor )
        {
           

            List<PlanMejoramientoM> listarPlanMejoramiento = oGestorD.MtObtenerPlanMejoramiento(IdGestor);
            return listarPlanMejoramiento;

        }

        public int MtEditarPlanMejoramiente(GestorM oGestor)
        {
            int Verifcacion = oGestorD.MtEditarPlanMejoramiento(oGestor);
            return Verifcacion;
            

        }

        public List<InstructorM> MtObtenerInstructor(int IdInstructor)
        {
            List<InstructorM> listarInstructor =oGestorD.MtObtenerInstructor(IdInstructor);
            return listarInstructor;
        }
    }


}