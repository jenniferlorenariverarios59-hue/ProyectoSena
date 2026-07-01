using ClosedXML.Excel;
using ProyectoSena.Datos;
using ProyectoSena.Logica;
using ProyectoSena.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoSena.Vista.Administrador.CrudAprendices
{
    public partial class Aprendices : System.Web.UI.Page
    {
        int IdAdmin = 0;
        public void MtCargarAprendices()
        {
            AprendizL oAprendizL = new AprendizL();
            gvAprendices.DataSource = oAprendizL.MtObtenerAprendiz(IdAdmin);

            gvAprendices.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IdAdmin = (int)Session["Id"];
            if (!IsPostBack)
            {
                MtCargarAprendices();
            }
        }

        protected void btnAgregarAprendiz_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearAprendiz.aspx");
        }

        protected void gvAprendices_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            AprendizL oAprendizL = new AprendizL();
            List<AprendizM> listaAprendices = oAprendizL.MtObtenerAprendiz(IdAdmin);

            if (e.CommandName == "Editar")
            {
                var codigo = e.CommandArgument;
                AprendizM aprendizSeleccionado =
                    listaAprendices.Find(x => x.Id == Convert.ToInt32(codigo));
                Session["EditarAprendiz"] = aprendizSeleccionado;

                Response.Redirect("EditarAprendiz.aspx");
            }
            else if (e.CommandName == "Eliminar")
            {
                var codigo = e.CommandArgument;
                AprendizM aprendizSeleccionado = listaAprendices.Find(u => u.Id == Convert.ToInt32(codigo));
                int verificacion = oAprendizL.MtEliminarAprendiz(aprendizSeleccionado);
                MtCargarAprendices();
            }
        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            if (!fuExcel.HasFile)
                return;

            List<AprendizM> listaProductoImportados = new List<AprendizM>();

            using (XLWorkbook productos = new XLWorkbook(fuExcel.PostedFile.InputStream))
            {
                IXLWorksheet hoja = productos.Worksheet(1);

                listaProductoImportados = hoja.RowsUsed()
                .Skip(1)
                .Select(fila => new AprendizM
                {
                    TipoDocumento = fila.Cell(1).GetString(),
                    NumeroDocumento = fila.Cell(2).GetString(),
                    Nombre = fila.Cell(3).GetString(),
                    Apellido = fila.Cell(4).GetString(),
                    Correo = fila.Cell(5).GetString(),
                    Contraseña = fila.Cell(6).GetString(),
                    Telefono = fila.Cell(7).GetString(),
                    Estado = "En Formacion",
                })
                .ToList();
                AprendizL oA = new AprendizL();
                int Verificacion = oA.MtCargaMasiva(listaProductoImportados);
                MtCargarAprendices();
                if (Verificacion > 0)
                {
                    string mensaje = $@"Swal.fire({{
        icon: 'success',
        title: '¡Exito!',
        text: 'Carga Masiva Completada, {Verificacion} Productos Registrados',
        timer: 2000,
        showConfirmButton: false
        }});";

                    ClientScript.RegisterStartupScript(this.GetType(), "Acceso", mensaje, true);
                }
            }
        }
        

        protected void btnDescargar_Click(object sender, EventArgs e)
        {

        }
    }
}