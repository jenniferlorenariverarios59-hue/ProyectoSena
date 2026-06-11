using ProyectoSena.Datos;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSena.Logica
{
    public class InstructorL
    {

        InstructorD oInstructorD = new InstructorD();

        public int MtRegistrarInstructor(InstructorM oInstructor)
        {
            int Verificacion = 0;

                Verificacion = oInstructorD.MtRegistrarInstructor(oInstructor);

            return Verificacion;

        }

        public List<InstructorM> MtObtenerInstructor(int IdAdmin)
        {
            List<InstructorM> listarInstructor = oInstructorD.MtObtenerInstructor(IdAdmin);
            return listarInstructor;
        }

        public int MtEditarInstructor(InstructorM oInstructor)
        {
            int Verificacion = oInstructorD.MtEditarInstructor(oInstructor);
            return Verificacion;
        }
        public int MtEliminarInstructor(InstructorM oInstructor)
        {
             int Verificacion = oInstructorD.MtEliminarInstructor (oInstructor);
            return Verificacion;
        }
    }
}