<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Estructura.Master" AutoEventWireup="true" CodeBehind="PlanesAsignados.aspx.cs" Inherits="ProyectoSena.Vista.Aprendiz.PlanesAsignados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Content -->

<div class="container-fluid p-4">
    <!-- Header -->
    <div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">
        <div>
            <h2 class="fw-bold">Planes de Mejoramiento Asignados </h2>
            <p class="text-muted">Visualiza los planes de mejoramiento asignados al aprendiz SENA. </p>
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
                    <asp:TemplateField HeaderText="Instructor">
                        <ItemTemplate>
                            <%# Eval("Instructor.Nombre") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <strong class="text-primary">
                                <%# Eval("PlanInternoComite.EstadoPlan") %>
                            </strong>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha de Asignacion">
                        <ItemTemplate>
                            <%# Eval("PlanInternoComite.FechaAsignacion") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha Limite">
                        <ItemTemplate>
                            <span class="badge badge-tech">
                                <%# Eval("PlanInternoComite.FechaLimite") %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Tipo de Plan">
                        <ItemTemplate>
                            <%# Eval("TipoPlan") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>

                            <asp:Button ID="btnEvidencias"
                                runat="server"
                                Text="Evidencias"
                                CssClass="btn btn-sm btn-outline-primary"
                                CommandName="SubirEvidencias"
                                CommandArgument='<%# Eval("Id") %>' />

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>
</asp:Content>
