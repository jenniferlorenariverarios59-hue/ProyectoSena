using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSena.Modelo
{
    public class InicioSesion
    {
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        public string Rol {  get; set; }
    }
}