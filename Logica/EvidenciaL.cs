using ProyectoSena.Datos;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace ProyectoSena.Logica
{
    public class EvidenciaL
    { 
       EvidenciaD oEvidenciaD = new EvidenciaD();

        public  int MtRegistrarEvidencia(Evidencia oEvidencia)
        {
            int Verificacion = 0;

            Verificacion = oEvidenciaD.MtRegistrarEvidencia(oEvidencia);

            return Verificacion;      
                   
        }
        public List<Evidencia> MtObtenerEvidencia()
        {

            List<Evidencia> listarEvdencia = oEvidenciaD.MtObtenerEvidencia();
                return listarEvdencia;
            
        }
        
        



        

    }
}