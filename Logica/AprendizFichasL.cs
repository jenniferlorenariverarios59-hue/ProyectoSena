using ProyectoSena.Datos;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<PlanMejoramiento> MtObtenerPlanes(int IdAprendiz)
        {
            AprendizFichasD oAprendizFichasD = new AprendizFichasD();
            List<PlanMejoramiento> listaPlanes = oAprendizFichasD.MtObtenerPlanes(IdAprendiz);
            return listaPlanes;
        }
    }
}