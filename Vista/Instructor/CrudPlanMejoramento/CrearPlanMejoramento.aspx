<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Estructura.Master" AutoEventWireup="true" CodeBehind="CrearPlanMejoramento.aspx.cs" Inherits="ProyectoSena.Vista.Instructor.CrudPlanMejoramento.CrearPlanMejoramento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="p-4">

        <!-- BREADCRUMB -->
        <nav class="mb-4">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="#">Inicio</a></li>
                <li class="breadcrumb-item"><a href="#">Planes Mejoramiento</a></li>
                <li class="breadcrumb-item active">Nuevo Plan Instructor</li>
            </ol>
        </nav>

        <!-- HEADER -->
        <div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">
            <div>
                <h2 class="fw-bold">Crear Nuevo Plan de Mejoramiento</h2>
                <p class="text-muted">
                    Registre la información básica para un nuevo plan de mejoramiento.
           
                </p>
            </div>

            <div class="d-flex gap-3">
                <button type="button" class="btn btn-outline-secondary px-4">
                    Cancelar
           
                </button>

                <asp:Button ID="btnGuargarPlanMejoramiento"
                    runat="server"
                    Text="Guardar Plan"
                    CssClass="btn btn-green px-4"
                    OnClick="btnGuargarPlanMejoramiento_Click" />
            </div>
        </div>

        <!-- FORM CARD -->
        <div class="form-card">

            <!-- INFORMACIÓN GENERAL -->
            <div class="section-title">Información General</div>

            <div class="row g-4">

                <div class="col-md-6">
                    <label class="form-label fw-semibold">
                        Fecha de asignación
               
                    </label>

                    <asp:TextBox ID="txtFechaAsignacion"
                        runat="server"
                        TextMode="Date"
                        CssClass="form-control form-control-lg">
                </asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label class="form-label fw-semibold">
                        Fecha límite
               
                    </label>

                    <asp:TextBox ID="txtFechaLimite"
                        runat="server"
                        TextMode="Date"
                        CssClass="form-control form-control-lg">
                </asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label class="form-label fw-semibold">
                        Estado del plan
               
                    </label>

                    <asp:TextBox ID="txtEstado"
                        runat="server"
                        CssClass="form-control form-control-lg">
                </asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label class="form-label fw-semibold">
                        Seleccione el aprendiz
               
                    </label>

                    <asp:DropDownList ID="ddlAprendiz"
                        runat="server"
                        CssClass="form-select form-select-lg"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ddlAprendiz_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>

            </div>

            <!-- RESULTADOS DE APRENDIZAJE -->
            <div class="section-title mt-5">
                Resultados de Aprendizaje Incumplidos
       
            </div>

            <div class="row g-4">

                <div class="col-12">

                    <label class="form-label fw-semibold">
                        Seleccione los resultados incumplidos que harán parte del plan
               
                    </label>

                    <div class="border rounded p-3 bg-light">

                        <asp:CheckBoxList
                            ID="cblResultados"
                            runat="server"
                            RepeatDirection="Vertical">
                        </asp:CheckBoxList>

                    </div>

                </div>

            </div>

            <!-- ACTIVIDADES -->
            <div class="section-title mt-5">
                Actividades Propuestas
       
            </div>

            <div class="row g-4">

                <div class="col-md-6">
                    <label class="form-label fw-semibold">
                        Nombre de la actividad
               
                    </label>

                    <asp:TextBox ID="txtNombreActividad"
                        runat="server"
                        CssClass="form-control form-control-lg">
                </asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label class="form-label fw-semibold">
                        Descripción
               
                    </label>

                    <asp:TextBox ID="txtDescripcionActividad"
                        runat="server"
                        CssClass="form-control form-control-lg">
                </asp:TextBox>
                </div>

                <div class="col-12">
                    <asp:Button ID="btnAgregarActividad"
                        runat="server"
                        Text="Agregar Actividad"
                        CssClass="btn btn-primary"
                        OnClick="btnAgregarActividad_Click" />
                </div>

            </div>

            <!-- GRID ACTIVIDADES -->
            <div class="mt-4">

                <asp:GridView ID="gvActividades"
                    runat="server"
                    AutoGenerateColumns="False"
                    CssClass="table table-striped table-bordered">

                    <Columns>

                        <asp:BoundField
                            DataField="Nombre"
                            HeaderText="Actividad" />

                        <asp:BoundField
                            DataField="Descripcion"
                            HeaderText="Descripción" />

                    </Columns>

                </asp:GridView>

            </div>

            <!-- INFO -->
            <div class="row g-4 mt-4">

                <div class="col-md-6">
                    <div class="info-box bg-primary bg-opacity-10">
                        <h5 class="text-primary fw-bold">Validación Automática
                    </h5>

                        <p class="mb-0 text-muted">
                            El sistema validará automáticamente la información ingresada.
                   
                        </p>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="info-box bg-light">
                        <h5 class="fw-bold">Documentación
                    </h5>

                        <p class="mb-0 text-muted">
                            Podrá adjuntar documentos después de guardar.
                   
                        </p>
                    </div>
                </div>

            </div>

        </div>

    </main>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>

</asp:Content>
