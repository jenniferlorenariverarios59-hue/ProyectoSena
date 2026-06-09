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
    public partial class EditarInstructor : System.Web.UI.Page
    {
        int IdAdmin = 0;
        public void MtCargarFichas()
        {
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
        protected void Page_Load(object sender, EventArgs e)
        {
            IdAdmin = (int)Session["Id"];
            if (!IsPostBack)
            {
                MtCargarFichas();
                Instructor oInstructor = (Instructor)Session["EditarInstructor"];
                ddlTipoDocumento.Text = oInstructor.TipoDocumento;
                txtNumeroDocumento.Text = oInstructor.NumeroDocumento;
                txtNombres.Text = oInstructor.Nombre;
                txtApellidos.Text = oInstructor.Apellido;
                txtCorreo.Text = oInstructor.Correo;
                txtTelefono.Text = oInstructor.Telefono;
                txtEspecialidad.Text = oInstructor.Especialidad;
            }
        }

        protected void btnGuardarInstructor_Click(object sender, EventArgs e)
        {
            FichaL oFichaL = new FichaL();
            List<Ficha> listaFichas = oFichaL.MtObtenerFicha(IdAdmin);

            Instructor oInstructorV = (Instructor)Session["EditarInstructor"];
            Instructor oInstructorE = new Instructor();
            oInstructorE.Id = oInstructorV.Id;
            oInstructorE.TipoDocumento = ddlTipoDocumento.Text;
            oInstructorE.NumeroDocumento = txtNumeroDocumento.Text;
            oInstructorE.Nombre = txtNombres.Text;
            oInstructorE.Apellido = txtApellidos.Text;
            oInstructorE.Correo = txtCorreo.Text;
            oInstructorE.Telefono = txtTelefono.Text;
            oInstructorE.Especialidad = txtEspecialidad.Text;
            string codigoFicha = ddlFicha.SelectedValue;

            var FichaSeleccionada = listaFichas.Find(u => u.codigoFicha == codigoFicha);
            oInstructorE.IdFicha = FichaSeleccionada.Id;

            InstructorL oInstructorL = new InstructorL();

            int verificacion = oInstructorL.MtEditarInstructor(oInstructorE);

            if (verificacion > 0)
            {
                string mensaje = @"Swal.fire({
                icon: 'success',
                title: '¡Exito!',
                text: 'Instructor Editado',
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
                text: 'no se pudo editar el instructor',
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