using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSena.Modelo
{
    public class AdministradorM
    {
        public int Id { get; set; }

        public string TipoDocumento { get; set; }

        public string NumeroDocumento { get; set; } 

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }
        public int IdCentro { get; set; }
        public string NombreCentro { get; set; }


    }
}