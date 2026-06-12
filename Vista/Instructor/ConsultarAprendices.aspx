<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Estructura.Master" AutoEventWireup="true" CodeBehind="ConsultarAprendices.aspx.cs" Inherits="ProyectoSena.Vista.Instructor.ConsultarAprendices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Content -->

    <div class="container-fluid p-4">
        <!-- Header -->
        <div class="d-flex justify-content-between align-items-center flex-wrap gap-3 mb-4">
            <div>
                <h2 class="fw-bold">Gestión de Aprendices </h2>
                <p class="text-muted">Organiza los Aprendices del SENA. </p>
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
                                    <%# Eval("Apellido") %>
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
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
