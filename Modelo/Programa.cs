using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace ProyectoSena.Modelo
{
    public class Programa
    {
        public int Id { get; set; }
        public string CodigoPrograma { get; set; }
        public string Nombre { get; set; }
        public string Vesion {  get; set; }
        public string Nivel { get; set; }
        public string Duracion { get; set; }
        public string Estado { get; set; }
        public int IdAdmin { get; set; }
        

    }
}