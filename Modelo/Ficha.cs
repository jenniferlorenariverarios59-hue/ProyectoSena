 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSena.Modelo
{
    public class Ficha
    {
        public int Id { get; set; }
        public string codigoFicha { get; set; }
        public Programa NombrePrograma { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public string Jornada { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

    }
}