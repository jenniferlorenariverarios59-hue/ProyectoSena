using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSena.Modelo
{
    public class GestorM
    {
         public int Id { get; set; }

        public string TipoDocumento  { get; set; }

        public string NumeroDocumento { get; set; } 


        public string Nombre {  get; set; }


        public  string Apellido { get; set; } 

        public string Correo { get; set; }


        public string  Contraseña { get; set; }

        public PlanMejoramientoM PlanMejoramiento { get; set; }






    }
}