using ProyectoSena.Datos;
using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista.Administrador.CrudInstructores
{
    public partial class CrearInstructor : System.Web.UI.Page
    {
        int IdAdmin = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdAdmin = (int)Session["Id"];
            if (!IsPostBack)
            {
                FichaL oFichaL = new FichaL();
                List<Ficha> listaFichas = oFichaL.MtObtenerFicha(IdAdmin);
                ddlFicha.DataSource = listaFichas;
                ddlFicha.DataTextField = "codigoFicha";
                ddlFicha.DataValueField = "codigoFicha";
                ddlFicha.DataBind();
            }
        }

        protected void btnGuardarInstructor_Click(object sender, EventArgs e)
        {
            FichaL oFichaL = new FichaL();
            List<Ficha> listaFichas = oFichaL.MtObtenerFicha(IdAdmin);

            Instructor oInstructor = new Instructor();
            oInstructor.TipoDocumento = ddlTipoDocumento.Text;
            oInstructor.NumeroDocumento = txtNumeroDocumento.Text;
            oInstructor.Nombre = txtNombres.Text;
            oInstructor.Apellido = txtApellidos.Text;
            oInstructor.Correo = txtCorreo.Text;
            oInstructor.Contraseña = txtContraseña.Text;
            oInstructor.Telefono = txtTelefono.Text;
            oInstructor.Especialidad = txtEspecialidad.Text;
            string codigoFicha = ddlFicha.SelectedValue;

            var FichaSeleccionada = listaFichas.Find(u => u.codigoFicha == codigoFicha);
            oInstructor.IdFicha = FichaSeleccionada.Id;

            InstructorL oInstructorL = new InstructorL();

            int verificacion = oInstructorL.MtRegistrarInstructor(oInstructor);

            if (verificacion > 0)
            {
                string mensaje = @"Swal.fire({
                icon: 'success',
                title: '¡Exito!',
                text: 'Instructor Registrado',
                timer: 2000,
                showConfirmButton: false
                }).then(() => {
                window.location.href = 'Instructores.aspx';
                });";

                ClientScript.RegisterStartupScript(this.GetType(), "Acceso", mensaje, true);
            }
            else
            {
                string mensaje = @"Swal.fire({
                icon: 'error',
                title: '¡Error!',
                text: 'No se pudo registrar el instructor',
                timer: 2000,
                showConfirmButton: false
                }).then(() => {
                window.location.href = 'Instructores.aspx';
                });";

                ClientScript.RegisterStartupScript(this.GetType(), "Acceso", mensaje, true);
            }
        }
    }
}