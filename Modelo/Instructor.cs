using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace ProyectoSena.Modelo
{
    public class Instructor
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Correo { get; set; }
        public string Contraseña { get; set; }

        public string Telefono { get; set; }

        public string Especialidad { get; set; }
        public int IdFicha { get; set; }

    }
}