using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista.CrudProgramas
{
    public partial class CrearPrograma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuargarPrograma_Click(object sender, EventArgs e)
        {
            Programa oPrograma = new Programa();
            oPrograma.CodigoPrograma = txtCodigoPrograma.Text;
            oPrograma.Nombre = txtNombre.Text;
            oPrograma.Vesion = txtVersion.Text;
            oPrograma.Nivel = ddlNivel.Text;
            oPrograma.Duracion = txtDuracion.Text;
            oPrograma.Estado = rbEstado.Checked ? "Activo" : "Inactivo";
            oPrograma.IdAdmin = Convert.ToInt32(Session["Id"]);

            ProgramaL oProgramaL = new ProgramaL();

            int verificacion = oProgramaL.MtRegistroPrograma(oPrograma);

            if (verificacion > 0)
            {
                string mensaje = @"Swal.fire({
                icon: 'success',
                title: '¡Exito!',
                text: 'Programa Registrado',
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
                text: 'No se pudo registrar el programa',
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