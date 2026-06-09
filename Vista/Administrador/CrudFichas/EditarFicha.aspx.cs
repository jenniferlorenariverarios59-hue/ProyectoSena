using ProyectoSena.Datos;
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
    public partial class EditarFicha : System.Web.UI.Page
    {
        int IdAdmin = 0;

        public void MtCargarProgramas()
        {
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
            
        protected void Page_Load(object sender, EventArgs e)
        {
            IdAdmin = (int)Session["Id"]; 

            if (!IsPostBack)
            {
                MtCargarProgramas();

                Ficha oFicha = (Ficha)Session["EditarFicha"];

                txtCodigoFicha.Text = oFicha.codigoFicha;
                txtFechaInicio.Text = oFicha.FechaInicio.ToString();
                txtFechaFinalizacion.Text = oFicha.FechaFinalizacion.ToString();
                txtJornada.Text = oFicha.Jornada;
                txtDescripcion.Text = oFicha.Descripcion;
                oFicha.NombrePrograma = new Programa();
                ddlPrograma.Text = oFicha.NombrePrograma.Nombre;
            }
        }

        protected void btnGuargarFicha_Click(object sender, EventArgs e)
        {
            ProgramaL oProgramaL = new ProgramaL();
            List<Programa> listaProgramas = oProgramaL.MtObtenerProgramas(IdAdmin);

            Ficha oFichaV = (Ficha)Session["EditarFicha"];
            Ficha oFichaE = new Ficha();
            oFichaE.Id = oFichaV.Id; 
            oFichaE.codigoFicha = txtCodigoFicha.Text;
            oFichaE.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
            oFichaE.FechaFinalizacion = Convert.ToDateTime(txtFechaFinalizacion.Text);
            oFichaE.Jornada = txtJornada.Text;
            oFichaE.Descripcion = txtDescripcion.Text;
            oFichaE.Estado = rbEstado.Checked ? "Activo" : "Inactivo";
            oFichaE.NombrePrograma = new Programa();
            oFichaE.NombrePrograma.Nombre = ddlPrograma.SelectedValue;

            var programaSeleccionado = listaProgramas.Find(u => u.Nombre == oFichaE.NombrePrograma.Nombre);
            oFichaE.NombrePrograma.Id = programaSeleccionado.Id;

            FichaL oFichaL = new FichaL();

            int verificacion = oFichaL.MtEditarFicha(oFichaE);

            if (verificacion > 0)
            {
                string mensaje = @"Swal.fire({
                icon: 'success',
                title: '¡Exito!',
                text: 'Ficha Editada',
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
                text: 'No se pudo editar la ficha',
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