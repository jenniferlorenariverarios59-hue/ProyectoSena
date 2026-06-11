using ProyectoSena.Datos;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace ProyectoSena.Logica
{
    public class InicioSesionL

    {
        InicioSesionD oInicioD = new InicioSesionD();
        public AprendizM MtInicioSesionAprendiz (InicioSesion oinicioSesion)
        {

            AprendizM oAprendiz = oInicioD.MtInicioAprendiz(oinicioSesion);

            return oAprendiz;
        }
       

        public InstructorM MtInicioSesionInstructor(InicioSesion oinicioSesion)
        {
            InstructorM oIstructor = oInicioD.MtInicioInstructor (oinicioSesion);

            return oIstructor;
        }

        public AdministradorM MtInicioAdministrador(InicioSesion oinicioSesion)
        {
            AdministradorM oAdministrador  = oInicioD.MtInicioAdministrador (oinicioSesion);
            return oAdministrador;
        }
    }
}
