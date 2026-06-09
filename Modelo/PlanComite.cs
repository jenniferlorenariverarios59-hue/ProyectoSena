using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSena.Modelo
{
    public class PlanComite
    {
        public int Id { get; set; }

        public DateTime FechaAsignacion { get; set; }

        public DateTime FechaLimite { get; set; }

        public string EstadoPlan { get; set; }

        public string ResultadosIncumplidos { get; set; }

        public string EvaluacionProducto { get; set; }

        public string EvaluacionConocimiento { get; set; }

        public string EvaluacionDesempeno { get; set; }
    }
}