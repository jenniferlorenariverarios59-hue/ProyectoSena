<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Estructura.Master" AutoEventWireup="true" CodeBehind="FichasAprendiz.aspx.cs" Inherits="ProyectoSena.Vista.Aprendiz.FichasAprendiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Content -->

<div class="container-fluid p-4">
    <!-- Header -->
    <div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">
        <div>
            <h2 class="fw-bold">Gestión de Fichas de Formación </h2>
            <p class="text-muted">Administra y organiza las fichas del SENA. </p>
        </div>
    </div>
    <!-- Table -->
    <div class="table-container">
        <div class="p-4 border-bottom d-flex justify-content-between align-items-center">
            <h4 class="m-0">Listado de Fichas Asignadas </h4>
        </div>
        <div class="table-responsive">
            <asp:GridView ID="gvFichas" class="table align-middle mb-0" runat="server" AutoGenerateColumns="false" OnRowCommand="gvFichas_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Código">
                        <ItemTemplate>
                            <%# Eval("CodigoFicha") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Programa">
                        <ItemTemplate>
                            <strong class="text-primary">
                                <%# Eval("NombrePrograma.Nombre") %>
                            </strong>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha de inicio">
                        <ItemTemplate>
                            <%# Eval("FechaInicio") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha de finalización">
                        <ItemTemplate>
                            <span class="badge badge-tech">
                                <%# Eval("FechaFinalizacion") %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Jornada">
                        <ItemTemplate>
                            <%# Eval("Jornada") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Descripción">
                        <ItemTemplate>
                            <%# Eval("Descripcion") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <span class="text-success fw-bold">● <%# Eval("Estado") %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>
</asp:Content>
