using ProyectoSena.Datos;
using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using ProyectoSena.Vista.Administrador.CrudFichas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista.Administrador.CrudAprendices
{
    public partial class CrearAprendiz : System.Web.UI.Page
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
                ddlFicha.DataValueField = "Id";
                ddlFicha.DataBind();
            }
        }

        protected void btnGuardarAprendiz_Click(object sender, EventArgs e)
        {
            FichaL oFichaL = new FichaL();
            List<Ficha> listaFichas = oFichaL.MtObtenerFicha(IdAdmin);

            AprendizM oAprendiz = new AprendizM();
            oAprendiz.TipoDocumento = ddlTipoDocumento.Text;
            oAprendiz.NumeroDocumento = txtNumeroDocumento.Text;
            oAprendiz.Nombre = txtNombres.Text;
            oAprendiz.Apellido = txtApellidos.Text;
            oAprendiz.Correo = txtCorreo.Text;
            oAprendiz.Contraseña = txtContraseña.Text;
            oAprendiz.Telefono = txtTelefono.Text;
            oAprendiz.Ficha = new Ficha();
            oAprendiz.Ficha.Id = Convert.ToInt32(ddlFicha.SelectedValue);

            
            AprendizL oAprendizL = new AprendizL();

            int verificacion = oAprendizL.MtRegistrarAprendiz(oAprendiz);

            if (verificacion > 0)
            {
                string mensaje = @"Swal.fire({
                icon: 'success',
                title: '¡Exito!',
                text: 'Aprendiz Registrado',
                timer: 2000,
                showConfirmButton: false
                }).then(() => {
                window.location.href = 'Aprendices.aspx';
                });";

                ClientScript.RegisterStartupScript(this.GetType(), "Acceso", mensaje, true);
            }
            else
            {
                string mensaje = @"Swal.fire({
                icon: 'error',
                title: '¡Error!',
                text: 'No se pudo registrar el aprendiz',
                timer: 2000,
                showConfirmButton: false
                }).then(() => {
                window.location.href = 'Aprendices.aspx';
                });";

                ClientScript.RegisterStartupScript(this.GetType(), "Acceso", mensaje, true);
            }
        }
    }
}