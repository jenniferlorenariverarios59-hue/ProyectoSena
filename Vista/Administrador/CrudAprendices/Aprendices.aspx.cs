using ProyectoSena.Datos;
using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista.Administrador.CrudAprendices
{
    public partial class Aprendices : System.Web.UI.Page
    {
        int IdAdmin = 0;
        public void MtCargarAprendices()
        {
            AprendizL oAprendizL = new AprendizL();
            gvAprendices.DataSource = oAprendizL.MtObtenerAprendiz(IdAdmin);

            gvAprendices.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IdAdmin = (int)Session["Id"];
            if (!IsPostBack)
            {
                MtCargarAprendices();
            }
        }

        protected void btnAgregarAprendiz_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearAprendiz.aspx");
        }

        protected void gvAprendices_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            AprendizL oAprendizL = new AprendizL();
            List<AprendizM> listaAprendices = oAprendizL.MtObtenerAprendiz(IdAdmin);

            if (e.CommandName == "Editar")
            {
                var codigo = e.CommandArgument;
                AprendizM aprendizSeleccionado =
                    listaAprendices.Find(x => x.Id == Convert.ToInt32(codigo));
                Session["EditarAprendiz"] = aprendizSeleccionado;

                Response.Redirect("EditarAprendiz.aspx");
            }
            else if (e.CommandName == "Eliminar")
            {
                var codigo = e.CommandArgument;
                AprendizM aprendizSeleccionado = listaAprendices.Find(u => u.Id == Convert.ToInt32(codigo));
                int verificacion = oAprendizL.MtEliminarAprendiz(aprendizSeleccionado);
                MtCargarAprendices();
            }
        }
    }
}