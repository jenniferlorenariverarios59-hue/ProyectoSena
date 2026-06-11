using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInicioSesion_Click(object sender, EventArgs e)
        {
            InicioSesion oinicioSesion = new InicioSesion();
            oinicioSesion.Correo = txtCorreo.Text;
            oinicioSesion.Contraseña = txtContraseña.Text;
            oinicioSesion.Rol = ddlRol.Text;

            InicioSesionL oSesionL = new InicioSesionL();

            if (oinicioSesion.Rol == "Aprendiz")
            {
                AprendizM oAprendiz = oSesionL.MtInicioSesionAprendiz(oinicioSesion);
                if (oAprendiz != null)
                {
                    Session["Id"] = oAprendiz.Id;
                    Session["Nombre"] = oAprendiz.Nombre;
                    Session["CodigoFicha"] = oAprendiz.Ficha.codigoFicha;
                    Session["NombrePrograma"] = oAprendiz.Ficha.NombrePrograma.Nombre;
                    Session["Rol"] = oinicioSesion.Rol;
                    Response.Redirect("~/Vista/Aprendiz/FichasAprendiz.aspx");
                }
                else
                {
                    string mensaje = @"Swal.fire({
                                     icon: 'error',
                                     title: '¡Error!',
                                     text: 'Correo y/o contraseña invalidos',
                                     timer: 2000,
                                     showConfirmButton: false
                                    }).then(() => {
                                    window.location.href = 'Inicio.aspx';
                                    });";

                    ClientScript.RegisterStartupScript(this.GetType(), "Acceso", mensaje, true);
                }

            }
            else if (oinicioSesion.Rol == "Instructor")
            {
                InstructorM oInstructor = oSesionL.MtInicioSesionInstructor(oinicioSesion);
                if (oInstructor != null)
                {
                    Session["Id"] = oInstructor.Id;
                    Session["Nombre"] = oInstructor.Nombre;
                    Session["Especialidad"] = oInstructor.Especialidad;
                    Session["Rol"] = oinicioSesion.Rol;
                }
                else
                {
                    string mensaje = @"Swal.fire({
                                     icon: 'error',
                                     title: '¡Error!',
                                     text: 'Correo y/o contraseña invalidos',
                                     timer: 2000,
                                     showConfirmButton: false
                                    }).then(() => {
                                    window.location.href = 'Inicio.aspx';
                                    });";

                    ClientScript.RegisterStartupScript(this.GetType(), "Acceso", mensaje, true);
                }
            }
            else if (oinicioSesion.Rol == "Administrador")
            {
                AdministradorM oAdministrador = oSesionL.MtInicioAdministrador(oinicioSesion);
                if (oAdministrador != null)
                {
                    Session["Id"] = oAdministrador.Id;
                    Session["Nombre"] = oAdministrador.Nombre;
                    Session["Rol"] = oinicioSesion.Rol;
                    Response.Redirect("~/Vista/Administrador/CrudProgramas/Programas.aspx");
                }
                else
                {
                    string mensaje = @"Swal.fire({
                                     icon: 'error',
                                     title: '¡Error!',
                                     text: 'Correo y/o contraseña invalidos',
                                     timer: 2000,
                                     showConfirmButton: false
                                    }).then(() => {
                                    window.location.href = 'Inicio.aspx';
                                    });";

                    ClientScript.RegisterStartupScript(this.GetType(), "Acceso", mensaje, true);
                }
            }






        }
    }
}