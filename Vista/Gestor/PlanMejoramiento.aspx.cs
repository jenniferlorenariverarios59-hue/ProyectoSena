using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista.Gestor
{
    public partial class PlanMejoramiento : System.Web.UI.Page
    {
        int IdGetor = 0;


        public void MtCargarPlanMejoramiento()
        {
            GestorL Ogestor = new GestorL();
            gvPlanesMejoramiento.DataSource = Ogestor.MtObtenerPlanMejoramiento(IdGetor);
            gvPlanesMejoramiento.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            IdGetor = (int)Session["Id"];
            if (!IsPostBack)
            {
                MtCargarPlanMejoramiento();
            }
        }

        protected void gvPlanesMejoramiento_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            GestorL oGestor = new GestorL();
            List<PlanMejoramientoM> listaplanMejora = oGestor.MtObtenerPlanMejoramiento(IdGetor);

            if( e. CommandName == "Editar")
            {
                var Codigo = e.CommandArgument;

                PlanMejoramientoM planselecionado =
                    listaplanMejora.Find(x => x.Id == Convert.ToInt32(Codigo));
                Session["PlanMejoramiento"] = planselecionado;

                Response.Redirect("EditarPlanMejoramiento.aspx");


            }

        }
    }
}