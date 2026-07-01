<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Estructura.Master" AutoEventWireup="true" CodeBehind="Aprendices.aspx.cs" Inherits="ProyectoSena.Vista.Administrador.CrudAprendices.Aprendices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Content -->

    <div class="container-fluid p-4">
        <!-- Header -->
        <div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">
            <div>
                <h2 class="fw-bold">Gestión de Aprendices </h2>
                <p class="text-muted">Administra y organiza los aprendices del SENA. </p>
            </div>
            <div class="d-flex gap-2">
                <asp:Button ID="btnAgregarAprendiz" class="btn btn-green" runat="server" Text="Agregar Aprendiz" OnClick="btnAgregarAprendiz_Click" />
            </div>
        </div>
        <!-- Table -->
        <div class="table-container">
            <div class="p-4 border-bottom d-flex justify-content-between align-items-center">
                <h4 class="m-0">Listado de Aprendices </h4>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="gvAprendices" class="table align-middle mb-0" runat="server" AutoGenerateColumns="false" OnRowCommand="gvAprendices_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Tipo de Documento">
                            <ItemTemplate>
                                <%# Eval("TipoDocumento") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Numero de Documento">
                            <ItemTemplate>
                                <%# Eval("NumeroDocumento") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nombres">
                            <ItemTemplate>
                                <%# Eval("Nombre") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Apellidos">
                            <ItemTemplate>
                                <span class="badge badge-tech">
                                    <%# Eval("Apellido") %>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Correo">
                            <ItemTemplate>
                                <%# Eval("Correo") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Telefono">
                            <ItemTemplate>
                                <%# Eval("Telefono") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ficha">
                            <ItemTemplate>
                                <%# Eval("Ficha.codigoFicha") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>

                                <asp:Button ID="btnEditar"
                                    runat="server"
                                    Text="Editar"
                                    CssClass="btn btn-sm btn-outline-primary"
                                    CommandName="Editar"
                                    CommandArgument='<%# Eval("Id") %>' />

                                <asp:Button ID="btnEliminar"
                                    runat="server"
                                    Text="Eliminar"
                                    CssClass="btn btn-sm btn-outline-danger"
                                    CommandName="Eliminar"
                                    CommandArgument='<%# Eval("Id") %>'
                                    OnClientClick="return confirmarEliminar(this);" />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

<div class="row mt-4">

    <div class="col-12">

        <div class="card shadow-sm">

            <div class="card-header bg-white">

                <div class="d-flex align-items-center">

                    <span class="material-symbols-outlined text-primary fs-2 me-3">cloud_upload
                    </span>

                    <div>

                        <h5 class="mb-1">Carga Masiva de Productos
                        </h5>

                        <small class="text-muted">Acelere su flujo de trabajo importando múltiples productos mediante archivos Excel o CSV.
                        </small>

                    </div>

                </div>

            </div>

            <div class="card-body">

                <div class="row">

                    <!-- Panel izquierdo -->

                    <div class="col-lg-3 mb-4">
                        <div class="card bg-light">

                            <div class="card-body">

                                <h6>Instrucciones
                                </h6>

                                <ul class="small">

                                    <li>Formato Excel (.xlsx)</li>

                                    <li>Formato CSV (.csv)</li>

                                    <li>Máximo 5.000 registros</li>

                                    <li>El SKU debe ser único.</li>

                                </ul>
                                <asp:Button ID="btnDescargar" runat="server" class="btn btn-outline-primary w-100" Text="Descargar Plantilla" OnClick="btnDescargar_Click" />


                            </div>

                        </div>

                    </div>

                    <!-- Zona Drag & Drop -->

                    <div class="col-lg-9">

                        <div id="drop-zone" class="drop-zone">

                            <!-- Vista inicial -->
                            <div id="vistaInicial">

                                <span class="material-symbols-outlined display-3 text-secondary mb-3">upload_file
                                </span>

                                <h4>Arrastre y suelte el archivo aquí</h4>

                                <p class="text-muted">
                                    o seleccione un archivo Excel (.xlsx)
                                </p>

                                <button
                                    id="btnSeleccionar"
                                    type="button"
                                    class="btn btn-primary rounded-circle shadow">
                                    +

                                </button>

                            </div>

                            <!-- Card del archivo -->
                            <div
                                id="cardArchivo"
                                class="card shadow border-0 d-none mt-3"
                                style="max-width: 500px; width: 100%;">

                                <div class="card-body">

                                    <div class="d-flex align-items-center">

                                        <div
                                            class="rounded-circle bg-success d-flex justify-content-center align-items-center me-3"
                                            style="width: 60px; height: 60px;">

                                            <span class="material-symbols-outlined text-white">description
                                            </span>

                                        </div>

                                        <div class="flex-grow-1">

                                            <h5
                                                id="nombreArchivo"
                                                class="mb-1 fw-bold"></h5>

                                            <small
                                                id="detalleArchivo"
                                                class="text-muted"></small>

                                        </div>

                                    </div>

                                    <hr />

                                    <div class="row">

                                        <div class="col-md-6 d-grid mb-2">

                                            <button
                                                id="btnEliminar"
                                                type="button"
                                                class="btn btn-outline-danger">
                                                🗑 Eliminar

                                            </button>

                                        </div>

                                        <div class="col-md-6 d-grid mb-2">

                                            <button
                                                id="btnCambiar"
                                                type="button"
                                                class="btn btn-outline-primary">
                                                🔄 Cambiar Archivo

                                            </button>

                                        </div>

                                    </div>

                                    <div class="d-grid mt-3">

                                        <asp:Button
                                            ID="btnImportar"
                                            runat="server"
                                            CssClass="btn btn-success btn-lg"
                                            Text="Importar Productos"
                                            OnClick="btnImportar_Click" />

                                    </div>

                                </div>

                            </div>

                            <asp:FileUpload
                                ID="fuExcel"
                                runat="server"
                                CssClass="d-none" />

                        </div>

                    </div>

                </div>

            </div>

        </div>

    </div>

    <!-- Fin Container -->


    <!-- ======================================= -->
    <!-- BOTÓN FLOTANTE -->
    <!-- ======================================= -->

    <button
        class="btn btn-primary rounded-circle shadow position-fixed bottom-0 end-0 m-4 d-lg-none"
        style="width: 65px; height: 65px;">

        <span class="material-symbols-outlined">add

        </span>

    </button>

                <script>

function confirmarEliminar() {

    event.preventDefault();

    let boton = event.target;

    Swal.fire({
        title: '¿Eliminar Aprendiz?',
        text: 'Esta acción no se puede deshacer',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sí, eliminar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {

        if (result.isConfirmed) {

            boton.onclick = null;

            boton.click();

        }

    });

    return false;
}

</script>


        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/js/bootstrap.bundle.min.js"></script>


 <!-- ======================================= -->
 <!-- DRAG & DROP -->
 <!-- ======================================= -->

 <script>

     const dropZone = document.getElementById("drop-zone");

     const fileInput = document.getElementById("<%= fuExcel.ClientID %>");

     const btnSeleccionar = document.getElementById("btnSeleccionar");

     const btnCambiar = document.getElementById("btnCambiar");

     const btnEliminar = document.getElementById("btnEliminar");

     const vistaInicial = document.getElementById("vistaInicial");

     const cardArchivo = document.getElementById("cardArchivo");

     const nombreArchivo = document.getElementById("nombreArchivo");

     const detalleArchivo = document.getElementById("detalleArchivo");

     btnSeleccionar.onclick = function () {

         fileInput.click();

     }

     function mostrarArchivo(file) {

         vistaInicial.classList.add("d-none");

         cardArchivo.classList.remove("d-none");

         nombreArchivo.innerHTML = file.name;

         let extension = file.name.split('.').pop().toUpperCase();

         let tamano = (file.size / 1024).toFixed(2);

         detalleArchivo.innerHTML = extension + " • " + tamano + " KB";

     }

     fileInput.onchange = function () {

         if (fileInput.files.length > 0) {

             mostrarArchivo(fileInput.files[0]);

         }

     }

     btnCambiar.onclick = function () {

         fileInput.click();

     }

     btnEliminar.onclick = function () {

         fileInput.value = "";

         cardArchivo.classList.add("d-none");

         vistaInicial.classList.remove("d-none");

     }

     ["dragenter", "dragover"].forEach(evento => {

         dropZone.addEventListener(evento, function (e) {

             e.preventDefault();

             dropZone.classList.add("border-primary", "bg-light");

         });

     });

     ["dragleave", "drop"].forEach(evento => {

         dropZone.addEventListener(evento, function (e) {

             e.preventDefault();

             dropZone.classList.remove("border-primary", "bg-light");

         });

     });

     dropZone.addEventListener("drop", function (e) {

         const archivos = e.dataTransfer.files;

         if (archivos.length == 0)
             return;

         const dt = new DataTransfer();

         dt.items.add(archivos[0]);

         fileInput.files = dt.files;

         mostrarArchivo(archivos[0]);

     });

 </script>
            </div>
        </div>
    </div>
</asp:Content>
