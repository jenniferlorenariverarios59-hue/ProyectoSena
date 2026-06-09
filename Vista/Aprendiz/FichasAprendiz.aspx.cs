using ProyectoSena.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista.Aprendiz
{
    public partial class FichasAprendiz : System.Web.UI.Page
    {
        int IdAprendiz = 0;
        public void MtCargarFichas()
        {
            AprendizFichasL oAprendizFichasL = new AprendizFichasL();
            gvFichas.DataSource = oAprendizFichasL.MtObtenerFichas(IdAprendiz);

            gvFichas.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IdAprendiz = (int)Session["Id"];
            if (!IsPostBack)
            {
                MtCargarFichas();
            }
        }

        protected void gvFichas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}