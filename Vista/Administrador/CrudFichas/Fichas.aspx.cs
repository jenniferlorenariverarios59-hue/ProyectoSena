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
    public partial class Fichas : System.Web.UI.Page
    {
        int IdAdmin = 0;
        public void MtCargarFichas()
        {
            FichaL oFichaL = new FichaL();
            gvFichas.DataSource = oFichaL.MtObtenerFicha(IdAdmin);

            gvFichas.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IdAdmin = (int) Session["Id"];
            if (!IsPostBack)
            {
                MtCargarFichas();
            }
        }

        protected void btnCrearFicha_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearFicha.aspx");
        }

        protected void gvFichas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            FichaL oFichaL = new FichaL();
            List<Ficha> listaFichas = oFichaL.MtObtenerFicha(IdAdmin);

            if (e.CommandName == "Editar")
            {
                var codigo = e.CommandArgument;
                Ficha fichaSeleccionada =
                    listaFichas.Find(x => x.Id == Convert.ToInt32(codigo));
                Session["EditarFicha"] = fichaSeleccionada;

                Response.Redirect("EditarFicha.aspx");
            }
            else if (e.CommandName == "Eliminar")
            {
                var codigo = e.CommandArgument;
                Ficha fichaSeleccionada = listaFichas.Find(u => u.Id == Convert.ToInt32(codigo));
                int verificacion = oFichaL.MtEliminarFicha(fichaSeleccionada);
                MtCargarFichas();
            }
        }
    }
}