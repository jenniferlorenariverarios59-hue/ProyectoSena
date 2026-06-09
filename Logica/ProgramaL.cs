using ProyectoSena.Datos;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSena.Logica
{
    public class ProgramaL
    {
        ProgramaD oProgramaD = new ProgramaD();
        public int MtRegistroPrograma(Programa oPrograma)
        {
            int verificacion = 0;

            verificacion = oProgramaD.MtRegistrarPrograma(oPrograma); 
            
            return verificacion;
        }

        public List<Programa> MtObtenerProgramas(int IdAdmin)
        {
            List<Programa> listaProgramas = oProgramaD.MtObtenerProgramas(IdAdmin);
            return listaProgramas;
        }

        public int MtEditarPrograma(Programa oPrograma)
        {
            int verificacion = oProgramaD.MtEditarProgramas(oPrograma);
            
            return verificacion;
        }

        public int MtEliminarprograma(Programa oPrograma)
        {
            int verificacion = oProgramaD.MtEliminarPrograma(oPrograma);
            return verificacion;
        }
    }
}