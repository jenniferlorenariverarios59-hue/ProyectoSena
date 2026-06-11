using ProyectoSena.Datos;
using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista.Instructor.CrudPlanMejoramento
{
    public partial class PlanesMejoramento : System.Web.UI.Page
    {
        int IdInstructor = 0;

        public void MtCargarPlanesMejoramiento()
        {
            PlanMejoramientoL oPlanMejoramentoL = new PlanMejoramientoL();
            gvPlanesMejoramiento.DataSource = oPlanMejoramentoL.MtObtenerPlanMejoramiento(IdInstructor);
            gvPlanesMejoramiento.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IdInstructor = (int)Session["Id"];
            if (!IsPostBack)
            {
                MtCargarPlanesMejoramiento();
            }
        }

        protected void btnCrearPlanMejoramiento_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearPlanMejoramiento.aspx");
        }

        protected void gvPlanesMejoramiento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            PlanMejoramientoL oPlanMejoramientoL = new PlanMejoramientoL();
            List<PlanMejoramiento> listaPlanMejoramiento = oPlanMejoramientoL.MtObtenerPlanMejoramiento(IdInstructor);

            if (e.CommandName == "Editar")
            {
                var codigo = e.CommandArgument;
                PlanMejoramiento planSeleccionado =
                    listaPlanMejoramiento.Find(x => x.Id == Convert.ToInt32(codigo));
                Session["EditarPlanMejoramiento"] = planSeleccionado;

                Response.Redirect("EditarPlanMejoramiento.aspx");
            }
            else if (e.CommandName == "Eliminar")
            {
                var codigo = e.CommandArgument;
                PlanMejoramiento planSeleccionado = listaPlanMejoramiento.Find(u => u.Id == Convert.ToInt32(codigo));
                int verificacion = oPlanMejoramientoL.MtEliminarPlanMejoramiento(planSeleccionado);
                MtCargarPlanesMejoramiento();
            }
        }
    }
}