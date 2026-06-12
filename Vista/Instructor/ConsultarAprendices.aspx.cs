using ProyectoSena.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista.Instructor
{
    public partial class ConsultarAprendices : System.Web.UI.Page
    {
        int IdInstructor = 0;
        public void MtCargarAprendices()
        {
            AprendizFichasL oAprendizFichasL = new AprendizFichasL();
            gvAprendices.DataSource = oAprendizFichasL.MtObtenerAprendicesDeInstructor(IdInstructor);

            gvAprendices.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IdInstructor = (int)Session["Id"];
            if (!IsPostBack)
            {
                MtCargarAprendices();
            }
        }

        protected void gvAprendices_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}