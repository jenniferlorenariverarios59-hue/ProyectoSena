<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Estructura.Master" AutoEventWireup="true" CodeBehind="EditarFicha.aspx.cs" Inherits="ProyectoSena.Vista.Administrador.CrudFichas.EditarFicha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- CONTENT -->
    <main class="p-4">
        <!-- BREADCRUMB -->
        <nav class="mb-4">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="#">Inicio </a></li>
                <li class="breadcrumb-item"><a href="#">Fichas </a></li>
                <li class="breadcrumb-item active">Editar Ficha </li>
            </ol>
        </nav>
        <!-- HEADER -->
        <div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">
            <div>
                <h2 class="fw-bold">Editar Ficha </h2>
                <p class="text-muted">Registre la información básica para editar una ficha educativa. </p>
            </div>
            <div class="d-flex gap-3">
                <button class="btn btn-outline-secondary px-4" href="Fichas.aspx">Cancelar </button>
                <asp:Button ID="btnGuargarFicha" class="btn btn-green px-4" runat="server" Text="Guardar Ficha" OnClick="btnGuargarFicha_Click" />
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
                        <label class="form-label fw-semibold">Código Ficha </label>
                        <asp:TextBox ID="txtCodigoFicha" class="form-control form-control-lg" runat="server" placeholder="Ej: 230101507"></asp:TextBox>
                    </div>
                    <!-- NOMBRE -->
                    <div class="col-6">
                        <label class="form-label fw-semibold">Fecha de inicio </label>
                        <asp:TextBox ID="txtFechaInicio" class="form-control form-control-lg" placeholder="YYYY/MM/DD" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-6">
                        <label class="form-label fw-semibold">Fecha de finalización </label>
                        <asp:TextBox ID="txtFechaFinalizacion" class="form-control form-control-lg" placeholder="YYYY/MM/DD" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-6">
                        <label class="form-label fw-semibold">Jornada </label>
                        <asp:TextBox ID="txtJornada" class="form-control form-control-lg" placeholder="Mañana/Tarde/Noche" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-12">
                        <label class="form-label fw-semibold">Descripción </label>
                        <asp:TextBox ID="txtDescripcion" class="form-control form-control-lg" placeholder="Escriba descripcion de la ficha" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label class="form-label fw-semibold">Programa de Formación </label>
                        <asp:DropDownList ID="ddlPrograma" class="form-select form-select-lg" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <!-- STATUS -->
                <div class="bg-light rounded-4 p-4 mt-5">
                    <div class="d-flex justify-content-between align-items-center flex-wrap gap-3">
                        <div>
                            <h5 class="fw-bold">Estado de la ficha </h5>
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
