using ProyectoSena.Datos;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSena.Logica
{
    public class FichaL
    {
        FichaD oFichaD= new FichaD();


        public int MtRegistroFicha(Ficha oFicha)
        {
            int Verificacion = 0;
            
            Verificacion = oFichaD.MtRegistrarFicha(oFicha);
            
            return Verificacion;

        }

        public List<Ficha> MtObtenerFicha(int IdAdmin)
        {
            List<Ficha> listarFicha = oFichaD.MtObtenerFicha(IdAdmin);
            return listarFicha;

        }
        public int MtEditarFicha(Ficha oFicha)
        {
            int Verificacion = oFichaD.MtEditarFicha(oFicha);
                return Verificacion;
        }

        public int MtEliminarFicha(Ficha oFicha)
        {
            int Verificacion = oFichaD.MtEliminarFicha(oFicha) ;
            return Verificacion;
        }



     
    }
}