using ProyectoSena.Vista.Aprendiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSena.Modelo
{
    public class PlanMejoramiento
    {
        public int Id { get; set; }

        public AprendizM Aprendiz { get; set; }

        public Instructor Instructor { get; set; }

        public PlanInterno PlanInternoComite { get; set; }

        public ActividadesPropuestas ActividadPropuesta { get; set; }

        public Observaciones Observacion { get; set; }

        public Evidencia Evidencia { get; set; }

        public string TipoPlan { get; set; }

    }
}