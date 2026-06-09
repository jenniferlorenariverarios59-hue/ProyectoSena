using ProyectoSena.Datos;
using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista.Administrador.CrudAprendices
{
    public partial class EditarAprendiz : System.Web.UI.Page
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
                AprendizM oAprendiz = (AprendizM)Session["EditarAprendiz"];
                ddlTipoDocumento.Text = oAprendiz.TipoDocumento;
                txtNumeroDocumento.Text = oAprendiz.NumeroDocumento;
                txtNombres.Text = oAprendiz.Nombre;
                txtApellidos.Text = oAprendiz.Apellido;
                txtCorreo.Text = oAprendiz.Correo;
                txtTelefono.Text = oAprendiz.Telefono;
            }
        }

        protected void btnGuardarAprendiz_Click(object sender, EventArgs e)
        {
            FichaL oFichaL = new FichaL();
            List<Ficha> listaFichas = oFichaL.MtObtenerFicha(IdAdmin);

            AprendizM oAprendizV = (AprendizM)Session["EditarAprendiz"];
            AprendizM oAprendizE = new AprendizM();
            oAprendizE.Id = oAprendizV.Id;
            oAprendizE.TipoDocumento = ddlTipoDocumento.Text;
            oAprendizE.NumeroDocumento = txtNumeroDocumento.Text;
            oAprendizE.Nombre = txtNombres.Text;
            oAprendizE.Apellido = txtApellidos.Text;
            oAprendizE.Correo = txtCorreo.Text;
            oAprendizE.Telefono = txtTelefono.Text;
            oAprendizE.Estado = ddlEstado.Text;
            oAprendizE.Ficha = new Ficha();
            oAprendizE.Ficha.codigoFicha = ddlFicha.SelectedValue;

            var FichaSeleccionada = listaFichas.Find(u => u.codigoFicha == oAprendizE.Ficha.codigoFicha);
            oAprendizE.Ficha.Id = FichaSeleccionada.Id;

            AprendizL oAprendizL = new AprendizL();

            int verificacion = oAprendizL.MtEditarAprendiz(oAprendizE);

            if (verificacion > 0)
            {
                string mensaje = @"Swal.fire({
                icon: 'success',
                title: '¡Exito!',
                text: 'Aprendiz Editado',
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
                text: 'no se pudo editar el aprendiz',
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