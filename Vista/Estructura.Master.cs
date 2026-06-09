using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rol = Session["Rol"].ToString();

            if (rol == "Administrador")
            {
                btnProgramas.Visible = true;
                btnFichas.Visible = true;
                btnInstructores.Visible = true;
                btnAprendices.Visible = true;
            }else if (rol == "Instructor")
            {
                
            }else if (rol == "Aprendiz")
            {
                btnFichasAprendiz.Visible = true;
                btnResultados.Visible = true;
                btnObservaciones.Visible = true;
                btnPlanesMejoramiento.Visible = true;
            }
        }

        protected void lnkCerrarsesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            string script = $@"Swal.fire({{
                icon: 'success',
                title: 'Sesión cerrada',
                text: 'Has cerrado sesión correctamente.',
                timer: 2000,
                showConfirmButton: false
                }}).then(() => {{
                window.location.href = '../Autenticacion/Inicio.aspx';
                }});";
 
            ScriptManager.RegisterStartupScript(this, GetType(), "CerrarSesion", script, true);
        }
    }
}