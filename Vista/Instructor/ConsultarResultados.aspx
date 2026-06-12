<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Estructura.Master" AutoEventWireup="true" CodeBehind="ConsultarResultados.aspx.cs" Inherits="ProyectoSena.Vista.Instructor.ConsultarResultados" %>

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
            <div class="d-flex gap-2">
                <asp:Button ID="btnCrearFicha" class="btn btn-green" runat="server" Text="Crear Ficha" OnClick="btnCrearFicha_Click" />
            </div>
        </div>
        <!-- Table -->
        <div class="table-container">
            <div class="p-4 border-bottom d-flex justify-content-between align-items-center">
                <h4 class="m-0">Listado de Fichas </h4>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="gvFichas" class="table align-middle mb-0" runat="server" AutoGenerateColumns="false" OnRowCommand="gvFichas_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <%# Eval("Nombre") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Programa">
                            <ItemTemplate>
                                
                                    <%# Eval("Estado") %>
                                
                            </ItemTemplate>
                        </asp:TemplateField>

                       
                    </Columns>
                </asp:GridView>
                

            </div>
        </div>
    </div>
</asp:Content>
