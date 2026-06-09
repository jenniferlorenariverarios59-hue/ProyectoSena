using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista.Administrador.CrudFichas
{
    public partial class CrearFicha : System.Web.UI.Page
    {
        int IdAdmin = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdAdmin = (int)Session["Id"];
            if (!IsPostBack)
            { 
                ProgramaL oProgramaL = new ProgramaL();
                List<Programa> listaProgramas = oProgramaL.MtObtenerProgramas(IdAdmin);
                ddlPrograma.DataSource = listaProgramas;
                ddlPrograma.DataTextField = "Nombre";
                ddlPrograma.DataValueField = "Nombre";
                ddlPrograma.DataBind();
            }
        }

        protected void btnGuargarFicha_Click(object sender, EventArgs e)
        {
            ProgramaL oProgramaL = new ProgramaL();
            List<Programa> listaProgramas = oProgramaL.MtObtenerProgramas(IdAdmin);

            Ficha oFicha = new Ficha();
            oFicha.codigoFicha = txtCodigoFicha.Text;
            oFicha.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
            oFicha.FechaFinalizacion = Convert.ToDateTime(txtFechaFinalizacion.Text);
            oFicha.Jornada = txtJornada.Text;
            oFicha.Descripcion = txtDescripcion.Text;
            oFicha.Estado = rbEstado.Checked ? "Activo" : "Inactivo";
            oFicha.NombrePrograma = new Programa();
            oFicha.NombrePrograma.Nombre = ddlPrograma.SelectedValue;

            var programaSeleccionado = listaProgramas.Find(u => u.Nombre == oFicha.NombrePrograma.Nombre);
            oFicha.NombrePrograma.Id = programaSeleccionado.Id;

            FichaL oFichaL = new FichaL();

            int verificacion = oFichaL.MtRegistroFicha(oFicha);

            if (verificacion > 0)
            {
                string mensaje = @"Swal.fire({
                icon: 'success',
                title: '¡Exito!',
                text: 'Ficha Registrada',
                timer: 2000,
                showConfirmButton: false
                }).then(() => {
                window.location.href = 'Fichas.aspx';
                });";

                ClientScript.RegisterStartupScript(this.GetType(), "Acceso", mensaje, true);
            }
            else
            {
                string mensaje = @"Swal.fire({
                icon: 'error',
                title: '¡Error!',
                text: 'No se pudo registrar la ficha',
                timer: 2000,
                showConfirmButton: false
                }).then(() => {
                window.location.href = 'Fichas.aspx';
                });";

                ClientScript.RegisterStartupScript(this.GetType(), "Acceso", mensaje, true);
            }
        }
    }
}