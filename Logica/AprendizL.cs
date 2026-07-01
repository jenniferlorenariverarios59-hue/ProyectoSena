using ProyectoSena.Datos;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSena.Logica
{
    public class AprendizL

    {

        AprendizD oAprendizD = new AprendizD();

        public int MtRegistrarAprendiz(AprendizM oAprendiz)
        {
            int Verificacion = 0;

            Verificacion = oAprendizD.MtRegistrarAprendiz(oAprendiz);

            return Verificacion;

        }

        public List<AprendizM> MtObtenerAprendiz(int IdAdmin)
        {
            List<AprendizM> listaAprendiz = oAprendizD.MtObtenerAprendiz(IdAdmin);
            return listaAprendiz;

        }

        public int MtEditarAprendiz(AprendizM oAprendiz)
        {
            int Verificacion = oAprendizD.MtEditarAprendiz(oAprendiz);
            return Verificacion;


        }

        public int MtEliminarAprendiz(AprendizM oAprendiz)
        {
            int Verificacion = oAprendizD.MtEliminarAprendiz(oAprendiz);
            return Verificacion;
        }

        public int MtCargaMasiva(List<AprendizM> listaaprendiz)
        {
            int Verificacion = oAprendizD.MtCargaMasiva(listaaprendiz);
            return Verificacion;
        }


    }
}