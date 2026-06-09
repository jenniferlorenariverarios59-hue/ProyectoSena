<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Estructura.Master" AutoEventWireup="true" CodeBehind="Programas.aspx.cs" Inherits="ProyectoSena.Vista.Programas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Content -->

    <div class="container-fluid p-4">
        <!-- Header -->
        <div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">
            <div>
                <h2 class="fw-bold">Gestión de Programas de Formación </h2>
                <p class="text-muted">Administra y organiza los programas del SENA. </p>
            </div>
            <div class="d-flex gap-2">
                <asp:Button ID="btnCrearPrograma" class="btn btn-green" runat="server" Text="Crear Programa" OnClick="btnCrearPrograma_Click" />
            </div>
        </div>
        <!-- Table -->
        <div class="table-container">
            <div class="p-4 border-bottom d-flex justify-content-between align-items-center">
                <h4 class="m-0">Listado de Programas </h4>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="gvProgramas" class="table align-middle mb-0" runat="server" AutoGenerateColumns="false" OnRowCommand="gvProgramas_RowCommand1">
                    <Columns>
                        <asp:TemplateField HeaderText="Código">
                            <ItemTemplate>
                                <%# Eval("CodigoPrograma") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Programa">
                            <ItemTemplate>
                                <strong class="text-primary">
                                    <%# Eval("Nombre") %>
                                </strong>
                                <br />
                                <small class="text-muted">
                                    <%# Eval("Duracion") %>
                                </small>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Versión">
                            <ItemTemplate>
                                <%# Eval("Vesion") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nivel">
                            <ItemTemplate>
                                <span class="badge badge-tech">
                                    <%# Eval("Nivel") %>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <span class="text-success fw-bold">● <%# Eval("Estado") %>
                                </span>
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
        title: '¿Eliminar programa?',
        text: 'Esta acción no se puede deshacer, se eliminaran las fichas asociadas',
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
