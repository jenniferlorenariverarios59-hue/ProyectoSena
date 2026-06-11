using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista.Administrador.CrudInstructores
{
    public partial class Instructores1 : System.Web.UI.Page
    {
        int IdAdmin = 0;
        public void MtCargarInstructores()
        {
            InstructorL oInstructorL = new InstructorL();
            gvInstructores.DataSource = oInstructorL.MtObtenerInstructor(IdAdmin);

            gvInstructores.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IdAdmin = (int)Session["Id"];
            if (!IsPostBack)
            {
                MtCargarInstructores();
            }
        }

        protected void btnAgregarInstructor_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearInstructor.aspx");
        }

        protected void gvInstructores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            InstructorL oInstructorL = new InstructorL();    
            List<InstructorM> listaInstructores = oInstructorL.MtObtenerInstructor(IdAdmin);

            if (e.CommandName == "Editar")
            {
                var codigo = e.CommandArgument;
                InstructorM instructorSeleccionado =
                    listaInstructores.Find(x => x.Id == Convert.ToInt32(codigo));
                Session["EditarInstructor"] = instructorSeleccionado;

                Response.Redirect("EditarInstructor.aspx");
            }
            else if (e.CommandName == "Eliminar")
            {
                var codigo = e.CommandArgument;
                InstructorM InstructorSeleccionado = listaInstructores.Find(u => u.Id == Convert.ToInt32(codigo));
                int verificacion = oInstructorL.MtEliminarInstructor(InstructorSeleccionado);
                MtCargarInstructores();
            }
        }
    }
}