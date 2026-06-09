using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista.Aprendiz
{
    public partial class PlanesAsignados : System.Web.UI.Page
    {
        int IdAprendiz = 0;
        public void MtCargarplanes()
        {
            AprendizFichasL oAprendizFichasL = new AprendizFichasL();
            gvPlanesMejoramiento.DataSource = oAprendizFichasL.MtObtenerPlanes(IdAprendiz);

            gvPlanesMejoramiento.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IdAprendiz = (int)Session["Id"];
            if (!IsPostBack)
            {
                MtCargarplanes();
            }
        }

        protected void gvPlanesMejoramiento_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}