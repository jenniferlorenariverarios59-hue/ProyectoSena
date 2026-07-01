using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlanM = ProyectoSena.Modelo.PlanMejoramientoM;

namespace ProyectoSena.Vista.Gestor
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public void  MtCargarInstructor(int IdGestor)
        {
            GestorL oResultadoL = new GestorL();

            var lista = oResultadoL.MtObtenerInstructor(IdGestor);

            cblResultados.DataSource = lista;
            cblResultados.DataTextField = "Nombre";
            cblResultados.DataValueField = "Id";
            cblResultados.DataBind();


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int IdGestor = 0;

            IdGestor = (int)Session["Id"];
            if (!IsPostBack)
            {


                Session["Actividades"] = new List<ActividadesPropuestas>();
                MtCargarInstructor(IdGestor);

                PlanM oPlanG = (PlanM)Session["EditarPlanMejoramiento "];

                lblFechaAsignacion.Text = oPlanG.PlanInternoComite.FechaAsignacion.ToString();
                lblAprendiz.Text = oPlanG.Aprendiz.Nombre;
                lblEstado.Text =oPlanG.PlanInternoComite.EstadoPlan.ToString();
                lblFechaLimite.Text = oPlanG.PlanInternoComite.FechaLimite.ToString();
                

                    


            }
        }
    }
}