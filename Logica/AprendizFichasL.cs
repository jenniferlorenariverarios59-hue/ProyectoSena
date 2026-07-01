using ProyectoSena.Datos;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace ProyectoSena.Logica
{
    public class AprendizFichasL
    {
        public List<Ficha> MtObtenerFichas (int IdAprendiz)
        {
            AprendizFichasD oAprendizFichasD = new AprendizFichasD ();
            List<Ficha> listaFichas = oAprendizFichasD.MtObtenerFichasAprendiz(IdAprendiz);
            return listaFichas;
        }

        public List<Observaciones> MtObtenerObservaciones(int IdAprendiz)
        {
            AprendizFichasD oAprendizFichasD = new AprendizFichasD();
            List<Observaciones> listaObservaciones = oAprendizFichasD.MtObtenerObservaciones(IdAprendiz);
            return listaObservaciones;
        }
        public List<PlanMejoramientoM> MtObtenerPlanes(int IdAprendiz)
        {
            AprendizFichasD oAprendizFichasD = new AprendizFichasD();
            List<PlanMejoramientoM> listaPlanes = oAprendizFichasD.MtObtenerPlanes(IdAprendiz);
            return listaPlanes;
        }

        public List<AprendizM> MtObtenerAprendicesDeInstructor(int IdInstructor)
        {
            AprendizFichasD oAprendizFichaD = new AprendizFichasD();
            List<AprendizM> listaAprendices = oAprendizFichaD.MtObtenerAprendicesDeInstructor(IdInstructor);
            return listaAprendices;
        }
    }
}