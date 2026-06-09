using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista.CrudProgramas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Programa oPrograma = (Programa)Session["EditarPrograma"];

                txtCodigoPrograma.Text = oPrograma.CodigoPrograma;
                txtNombre.Text = oPrograma.Nombre;
                txtVersion.Text = oPrograma.Vesion;
                txtDuracion.Text = oPrograma.Duracion;
                rbEstado.Text = oPrograma.Estado;
                ddlNivel.Text = oPrograma.Nivel;
            }
        }

        protected void btnGuargarPrograma_Click(object sender, EventArgs e)
        {
            Programa oProgramaV = (Programa)Session["EditarPrograma"];
            Programa oProgramaE = new Programa();
            oProgramaE.Id = oProgramaV.Id;
            oProgramaE.CodigoPrograma = txtCodigoPrograma.Text;
            oProgramaE.Nombre = txtNombre.Text;
            oProgramaE.Vesion = txtVersion.Text;
            oProgramaE.Duracion = txtDuracion.Text;
            oProgramaE.Nivel = ddlNivel.Text;
            oProgramaE.Estado = rbEstado.Checked ? "Activo" : "Inactivo";

            ProgramaL oProgramaL = new ProgramaL();

            int verificacion = oProgramaL.MtEditarPrograma(oProgramaE);

            if (verificacion > 0)
            {
                string mensaje = @"Swal.fire({
                icon: 'success',
                title: '¡Exito!',
                text: 'Programa Editado',
                timer: 2000,
                showConfirmButton: false
                }).then(() => {
                window.location.href = 'Programas.aspx';
                });";

                ClientScript.RegisterStartupScript(this.GetType(), "Acceso", mensaje, true);
            }
            else
            {
                string mensaje = @"Swal.fire({
                icon: 'error',
                title: '¡Error!',
                text: 'No se pudo editar el programa',
                timer: 2000,
                showConfirmButton: false
                }).then(() => {
                window.location.href = 'Programas.aspx';
                });";

                ClientScript.RegisterStartupScript(this.GetType(), "Acceso", mensaje, true);
            }
        }
    }
}