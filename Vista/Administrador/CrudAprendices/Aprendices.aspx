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
            </div>
        </div>
    </div>
</asp:Content>
