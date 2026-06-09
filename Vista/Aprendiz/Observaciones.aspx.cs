using ProyectoSena.Logica;
using ProyectoSena.Vista.Administrador.CrudFichas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista.Aprendiz
{
    public partial class Observaciones : System.Web.UI.Page
    {
        int IdAprendiz = 0;
        public void MtCargarObservaciones()
        {
            AprendizFichasL oAprendizFichasL = new AprendizFichasL();
            gvObservaciones.DataSource = oAprendizFichasL.MtObtenerObservaciones(IdAprendiz);

            gvObservaciones.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IdAprendiz = (int)Session["Id"];
            if (!IsPostBack)
            {
                MtCargarObservaciones();
            }
        }

        protected void gvObservaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}