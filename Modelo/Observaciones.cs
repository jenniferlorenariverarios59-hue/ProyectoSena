using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSena.Modelo
{
    public class Observaciones
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion {  get; set; }
        public InstructorM nombreInstructor { get; set; }
    }
}