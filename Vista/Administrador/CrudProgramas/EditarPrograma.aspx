<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Estructura.Master" AutoEventWireup="true" CodeBehind="EditarPrograma.aspx.cs" Inherits="ProyectoSena.Vista.CrudProgramas.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- CONTENT -->
    <main class="p-4">
        <!-- BREADCRUMB -->
        <nav class="mb-4">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="#">Inicio </a></li>
                <li class="breadcrumb-item"><a href="#">Programas </a></li>
                <li class="breadcrumb-item active">Editar Programa </li>
            </ol>
        </nav>
        <!-- HEADER -->
        <div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">
            <div>
                <h2 class="fw-bold">Editar Programa </h2>
                <p class="text-muted">Registre la información básica para editar un programa educativo. </p>
            </div>
            <div class="d-flex gap-3">
                <button class="btn btn-outline-secondary px-4" href="Programas.aspx">Cancelar </button>
                <asp:Button ID="btnGuargarPrograma" class="btn btn-green px-4" runat="server" Text="Guargar Programa" OnClick="btnGuargarPrograma_Click" />
            </div>
        </div>
        <!-- FORM CARD -->
        <div class="form-card">
            <form>
                <!-- SECTION -->
                <div class="section-title">Información General </div>
                <div class="row g-4">
                    <!-- CODIGO -->
                    <div class="col-md-6">
                        <label class="form-label fw-semibold">Código Programa </label>
                        <asp:TextBox ID="txtCodigoPrograma" class="form-control form-control-lg" runat="server" placeholder="Ej: 230101507"></asp:TextBox>
                    </div>
                    <!-- VERSION -->
                    <div class="col-md-6">
                        <label class="form-label fw-semibold">Versión </label>
                        <asp:TextBox ID="txtVersion" class="form-control form-control-lg" placeholder="Ej: 1" runat="server"></asp:TextBox>
                    </div>
                    <!-- NOMBRE -->
                    <div class="col-12">
                        <label class="form-label fw-semibold">Nombre del Programa </label>
                        <asp:TextBox ID="txtNombre" class="form-control form-control-lg" placeholder="Ingrese el nombre completo" runat="server"></asp:TextBox>
                    </div>
                    <!-- NIVEL -->
                    <div class="col-md-6">
                        <label class="form-label fw-semibold">Nivel de Formación </label>
                        <asp:DropDownList ID="ddlNivel" class="form-select form-select-lg" runat="server">
                            <asp:ListItem>Seleccione un nivel</asp:ListItem>
                            <asp:ListItem>Técnico</asp:ListItem>
                            <asp:ListItem>Tecnólogo</asp:ListItem>
                            <asp:ListItem>Especialización</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <!-- DURACION -->
                    <div class="col-md-6">
                        <label class="form-label fw-semibold">Duración </label>
                        <asp:TextBox ID="txtDuracion" class="form-control form-control-lg" placeholder="24 meses" runat="server"></asp:TextBox>
                    </div>
                </div>
                <!-- STATUS -->
                <div class="bg-light rounded-4 p-4 mt-5">
                    <div class="d-flex justify-content-between align-items-center flex-wrap gap-3">
                        <div>
                            <h5 class="fw-bold">Estado del Programa </h5>
                            <p class="text-muted mb-0">Disponible para inscripciones. </p>
                        </div>
                        <div class="d-flex gap-4">
                            <asp:RadioButton ID="rbEstado" class="form-check-label" GroupName="estado" runat="server" Text="Activo" />
                            <asp:RadioButton ID="rb" class="form-check-label" GroupName="estado" runat="server" Text="Inactivo" />
                        </div>
                    </div>
                </div>
                <!-- INFO -->
                <div class="row g-4 mt-4">
                    <div class="col-md-6">
                        <div class="info-box bg-primary bg-opacity-10">
                            <h5 class="text-primary fw-bold">Validación Automática </h5>
                            <p class="mb-0 text-muted">El sistema validará automáticamente el código del programa. </p>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="info-box bg-light">
                            <h5 class="fw-bold">Documentación </h5>
                            <p class="mb-0 text-muted">Podrá adjuntar documentos después de guardar. </p>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </main>
    <!-- BOOTSTRAP -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
