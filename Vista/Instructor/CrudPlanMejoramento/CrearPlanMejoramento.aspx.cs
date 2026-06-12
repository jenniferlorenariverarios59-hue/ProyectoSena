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
    public partial class CrearPlanMejoramento : System.Web.UI.Page
    {
        int IdInstructor = 0;

        private void CargarResultadosAprendiz(int idAprendiz)
        {
            PlanMejoramientoL oResultadoL = new PlanMejoramientoL();

            var lista = oResultadoL.MtObtenerPendientesPorAprendiz(idAprendiz);

            cblResultados.DataSource = lista;
            cblResultados.DataTextField = "Nombre";
            cblResultados.DataValueField = "Id";
            cblResultados.DataBind();
        }
        public void MtCargarAprendices()
        {
            if (!IsPostBack)
            {
                AprendizFichasL oAprendizFichasL = new AprendizFichasL();
                List<AprendizM> listaAprendices = oAprendizFichasL.MtObtenerAprendicesDeInstructor(IdInstructor);
                ddlAprendiz.DataSource = listaAprendices;
                ddlAprendiz.DataTextField = "Nombre";
                ddlAprendiz.DataValueField = "Id";
                ddlAprendiz.DataBind();
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IdInstructor = (int)Session["Id"];
            if (!IsPostBack)    
            {
                Session["Actividades"] = new List<ActividadesPropuestas>();
                MtCargarAprendices();
            }
        }

        protected void btnGuargarPlanMejoramiento_Click(object sender, EventArgs e)
        {
            List<ActividadesPropuestas> actividades = (List<ActividadesPropuestas>)Session["Actividades"];

            AprendizFichasL oAprendizFichasL = new AprendizFichasL();
            List<AprendizM> listaAprendices = oAprendizFichasL.MtObtenerAprendicesDeInstructor(IdInstructor);

            PlanMejoramiento oPlanMejoramiento = new PlanMejoramiento();
            oPlanMejoramiento.Instructor = new InstructorM();
            oPlanMejoramiento.Instructor.Id = IdInstructor;
            oPlanMejoramiento.PlanInternoComite = new PlanInterno();
            oPlanMejoramiento.PlanInternoComite.FechaAsignacion = Convert.ToDateTime(txtFechaAsignacion.Text);
            oPlanMejoramiento.PlanInternoComite.FechaLimite = Convert.ToDateTime(txtFechaLimite.Text);
            oPlanMejoramiento.PlanInternoComite.EstadoPlan = txtEstado.Text;
            oPlanMejoramiento.ActividadPropuesta = (List<ActividadesPropuestas>)Session["Actividades"];
            oPlanMejoramiento.ResultadosIncumplidos = new List<int>();
            oPlanMejoramiento.Aprendiz = new AprendizM();
            oPlanMejoramiento.Aprendiz.Id = Convert.ToInt32(ddlAprendiz.SelectedValue);

            foreach (ListItem item in cblResultados.Items)
            {
                if (item.Selected)
                {
                    oPlanMejoramiento.ResultadosIncumplidos.Add(
                        Convert.ToInt32(item.Value));
                }
            }
            PlanMejoramientoL oPlanMejoramientoL = new PlanMejoramientoL();
            int Verificacion = oPlanMejoramientoL.MtRegistrarPlanMejoramento(oPlanMejoramiento);
            if (Verificacion > 0)
            {
                string mensaje = @"Swal.fire({
                icon: 'success',
                title: '¡Exito!',
                text: 'Plan de Mejoramiento Registrado',
                timer: 2000,
                showConfirmButton: false
                }).then(() => {
                window.location.href = 'PlanesMejoramento.aspx';
                });";

                ClientScript.RegisterStartupScript(this.GetType(), "Acceso", mensaje, true);
            }
            else
            {
                string mensaje = @"Swal.fire({
                icon: 'error',
                title: '¡Error!',
                text: 'No se pudo registrar el Plan de Mejoramiento',
                timer: 2000,
                showConfirmButton: false
                }).then(() => {
                window.location.href = 'PlanesMejoramento.aspx';
                });";

                ClientScript.RegisterStartupScript(this.GetType(), "Acceso", mensaje, true);
            }
            
        }

        protected void btnAgregarActividad_Click(object sender, EventArgs e)
        {
            List<ActividadesPropuestas> listaActividades = (List<ActividadesPropuestas>)Session["Actividades"];

            ActividadesPropuestas oActividad = new ActividadesPropuestas();

            oActividad.Nombre = txtNombreActividad.Text.Trim();
            oActividad.Descripcion = txtDescripcionActividad.Text.Trim();

            listaActividades.Add(oActividad);

            Session["Actividades"] = listaActividades;

            gvActividades.DataSource = listaActividades;
            gvActividades.DataBind();

            txtNombreActividad.Text = "";
            txtDescripcionActividad.Text = "";
        }

        protected void ddlAprendiz_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idAprendiz = Convert.ToInt32(ddlAprendiz.SelectedValue);

            if (idAprendiz > 0)
            {
                CargarResultadosAprendiz(idAprendiz);
            }
        }
    }
}