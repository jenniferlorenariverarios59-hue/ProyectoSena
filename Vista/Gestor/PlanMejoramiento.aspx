<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Estructura.Master" AutoEventWireup="true" CodeBehind="PlanMejoramiento.aspx.cs" Inherits="ProyectoSena.Vista.Gestor.PlanMejoramiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- Content -->

    <div class="container-fluid p-4">
        <!-- Header -->
        <div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">
            <div>
                <h2 class="fw-bold">Gestión de Planes de mejoramiento </h2>
                <p class="text-muted">Administra y organiza los planes de mejoramiento del SENA. </p>
            </div>
            <div class="d-flex gap-2">
               
            </div>
        </div>
        <!-- Table -->
        <div class="table-container">
            <div class="p-4 border-bottom d-flex justify-content-between align-items-center">
                <h4 class="m-0">Listado de Planes de Mejoramiento </h4>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="gvPlanesMejoramiento" class="table align-middle mb-0" runat="server" AutoGenerateColumns="false" OnRowCommand="gvPlanesMejoramiento_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Tipo de documento del aprendiz">
                            <ItemTemplate>
                                <%# Eval("Aprendiz.TipoDocumento") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Numero de documento del aprendiz">
                            <ItemTemplate>
                                <%# Eval("Aprendiz.NumeroDocumento") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nombre del aprendiz">
                            <ItemTemplate>
                                <%# Eval("Aprendiz.Nombre") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Apellidos del aprendiz">
                            <ItemTemplate>

                                <%# Eval("Aprendiz.Apellido") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fecha Asignacion">
                            <ItemTemplate>

                                <%# Eval("PlanInternoComite.FechaAsignacion") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fecha Limite">
                            <ItemTemplate>

                                <%# Eval("PlanInternoComite.FechaLimite") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>

                                <%# Eval("PlanInternoComite.EstadoPlan") %>
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
