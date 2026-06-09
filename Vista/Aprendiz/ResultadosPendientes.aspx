<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Estructura.Master" AutoEventWireup="true" CodeBehind="ResultadosPendientes.aspx.cs" Inherits="ProyectoSena.Vista.Aprendiz.ResultadosPendientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Content -->

    <div class="container-fluid p-4">
        <!-- Header -->
        <div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">
            <div>
                <h2 class="fw-bold">Gestión de Resultados de Aprendizaje </h2>
                <p class="text-muted">Organiza los resultados de aprendizaje del SENA. </p>
            </div>
        </div>
        <!-- Table -->
        <div class="table-container">
            <div class="p-4 border-bottom d-flex justify-content-between align-items-center">
                <h4 class="m-0">Listado de Resultados Pendientes </h4>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="gvResultados" class="table align-middle mb-0" runat="server" AutoGenerateColumns="false" OnRowCommand="gvResultados_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <%# Eval("Nombre") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Competencia">
                            <ItemTemplate>
                                <%# Eval("Competencia") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <strong class="text-primary">
                                    <%# Eval("Estado") %>
                                </strong>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
