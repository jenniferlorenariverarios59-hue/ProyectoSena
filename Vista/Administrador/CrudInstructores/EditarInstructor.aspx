<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Estructura.Master" AutoEventWireup="true" CodeBehind="EditarInstructor.aspx.cs" Inherits="ProyectoSena.Vista.Administrador.CrudInstructores.EditarInstructor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- CONTENT -->
    <main class="p-4">
        <!-- BREADCRUMB -->
        <nav class="mb-4">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="#">Inicio </a></li>
                <li class="breadcrumb-item"><a href="#">Instructores </a></li>
                <li class="breadcrumb-item active">Editar Instructor </li>
            </ol>
        </nav>
        <!-- HEADER -->
        <div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">
            <div>
                <h2 class="fw-bold">Editar Instructor </h2>
                <p class="text-muted">Registre la información básica para editar un instructor. </p>
            </div>
            <div class="d-flex gap-3">
                <button class="btn btn-outline-secondary px-4" href="Instructores.aspx">Cancelar </button>
                <asp:Button ID="btnGuardarInstructor" class="btn btn-green px-4" runat="server" Text="Guardar Instructor" OnClick="btnGuardarInstructor_Click" />
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
                        <label class="form-label fw-semibold">Tipo de Documento </label>
                        <asp:DropDownList ID="ddlTipoDocumento" class="form-control form-control-lg" runat="server">
                            <asp:ListItem>Seleccione el Tipo de Documento</asp:ListItem>
                            <asp:ListItem>Cedula de Ciudadania</asp:ListItem>
                            <asp:ListItem>Cedula de Extranjeria</asp:ListItem>
                            <asp:ListItem>Pasaporte</asp:ListItem>
                            <asp:ListItem>NIT</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <!-- VERSION -->
                    <div class="col-md-6">
                        <label class="form-label fw-semibold">Numero de Documento </label>
                        <asp:TextBox ID="txtNumeroDocumento" class="form-control form-control-lg" placeholder="Ej: 123456789" runat="server"></asp:TextBox>
                    </div>
                    <!-- NOMBRE -->
                    <div class="col-6">
                        <label class="form-label fw-semibold">Nombres </label>
                        <asp:TextBox ID="txtNombres" class="form-control form-control-lg" placeholder="Ingrese los nombres" runat="server"></asp:TextBox>
                    </div>
                    <!-- NIVEL -->
                    <div class="col-md-6">
                        <label class="form-label fw-semibold">Apellidos </label>
                        <asp:TextBox ID="txtApellidos" class="form-control form-control-lg" placeholder="Ingrese los apellidos" runat="server"></asp:TextBox>
                    </div>
                    <!-- DURACION -->
                    <div class="col-md-6">
                        <label class="form-label fw-semibold">Correo </label>
                        <asp:TextBox ID="txtCorreo" class="form-control form-control-lg" placeholder="instructor@sena.edu.co" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label fw-semibold">Telefono </label>
                        <asp:TextBox ID="txtTelefono" class="form-control form-control-lg" placeholder="123456789" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label fw-semibold">Especialidad </label>
                        <asp:TextBox ID="txtEspecialidad" class="form-control form-control-lg" placeholder="Ing.Sistemas" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label fw-semibold">Ficha de Formación </label>
                        <asp:DropDownList ID="ddlFicha" class="form-select form-select-lg" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <!-- INFO -->
                <div class="row g-4 mt-4">
                    <div class="col-md-6">
                        <div class="info-box bg-primary bg-opacity-10">
                            <h5 class="text-primary fw-bold">Validación Automática </h5>
                            <p class="mb-0 text-muted">El sistema validará automáticamente el número de documento. </p>
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
