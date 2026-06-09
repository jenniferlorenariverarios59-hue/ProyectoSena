using ProyectoSena.Datos;
using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista
{
    public partial class Programas : System.Web.UI.Page
    {
        int IdAdmin = 0;
        public void MtCargarProgramas()
        {
            
            ProgramaL oProgramaL = new ProgramaL();
            gvProgramas.DataSource = oProgramaL.MtObtenerProgramas(IdAdmin);

            gvProgramas.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IdAdmin = (int)Session["Id"];
            if (!IsPostBack)
            {
                MtCargarProgramas();
            }
        }

        protected void btnCrearPrograma_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearPrograma.aspx");
        }

        protected void gvProgramas_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            ProgramaL oProgramaL = new ProgramaL();
            List<Programa> listaProgramas = oProgramaL.MtObtenerProgramas(IdAdmin);

            if (e.CommandName == "Editar")
            {
                var codigo = e.CommandArgument;
                Programa programaSeleccionado =
                    listaProgramas.Find(x => x.Id == Convert.ToInt32(codigo));
                Session["EditarPrograma"] = programaSeleccionado;

                Response.Redirect("EditarPrograma.aspx");
            }else if (e.CommandName == "Eliminar")
            {
                var codigo = e.CommandArgument;
                Programa programaSeleccionado = listaProgramas.Find(u => u.Id == Convert.ToInt32(codigo));
                int verificacion = oProgramaL.MtEliminarprograma(programaSeleccionado);
                MtCargarProgramas();
            }

        }
    }
}