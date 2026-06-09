<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ProyectoSena.Vista.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sena</title>



    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700&display=swap" rel="stylesheet">

    <!-- Icons -->
    <link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined" rel="stylesheet">

    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>


    <link rel ="stylesheet" href ="../CSS/InicioSesion.css" />

</head>



<body>
    <form id="form1" runat="server">
        <div>
            

    <!-- Navbar -->
    <nav class="navbar navbar-expand-lg bg-white shadow-sm">
        <div class="container">

            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#menu">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="menu">
                <ul class="navbar-nav ms-auto align-items-lg-center gap-lg-3">
                </ul>
            </div>

        </div>
    </nav>

    <!-- Main -->
    <main class="container flex-grow-1 d-flex justify-content-center align-items-center py-5">

        <div class="login-card w-100" style="max-width: 430px;">

            <!-- Header -->
            <div class="mb-4">
                <h1 class="login-title">Bienvenido</h1>
                <p class="login-subtitle">
                    Inicie sesión para acceder a su portal de SENA.
                </p>
            </div>

            <!-- Form -->
            <form>

                <!-- Email -->
                <div class="mb-4">
                    <label class="form-label">
                        Correo electrónico
                    </label>

                    <asp:TextBox ID="txtCorreo" class="form-control" runat="server" placeholder="jenfer@1234"></asp:TextBox>
                    
                    

                </div>

                <!-- Password -->
                <div class="mb-4">

                    <div class="d-flex justify-content-between mb-2">
                        <label class="form-label mb-0">
                            Contraseña
                        </label>

                        <a href="#" class="text-success text-decoration-none small fw-semibold">
                            ¿Olvidó su contraseña?
                        </a>
                    </div>
                    <asp:TextBox ID="txtContraseña" class="form-control" runat="server" placeholder="(●'◡'●)(●'◡'●)"></asp:TextBox>
                </div>

                <!-- Role -->
                <div class="mb-4">
                    <label class="form-label">
                        Rol de Usuario
                    </label>

                    <asp:DropDownList ID="ddlRol" class="form-select" runat ="server">
                        <asp:ListItem>Aprendiz</asp:ListItem>
                        <asp:ListItem>Administrador</asp:ListItem>
                        <asp:ListItem>Instructor</asp:ListItem>

                    </asp:DropDownList>

                </div>

                <!-- Button -->
                <asp:Button ID="btnInicioSesion" class="btn btn-login w-100" runat="server" Text="Inicio Sesión" OnClick ="btnInicioSesion_Click"  />


            </form>

            <!-- Divider -->
            <div class="divider my-4">
                <hr>
                <span class="text-muted small fw-bold">O</span>
                <hr>
            </div>  

        </div>

    </main>

    <!-- Footer -->
    <footer class="py-4">
        <div class="container text-center">

            <p class="text-muted small mb-3">
                © <span id="year"></span> SENA. Todos los derechos reservados.
            </p>

            <div class="footer-links d-flex justify-content-center gap-3 flex-wrap">
                <a href="#">Política de Privacidad</a>
                <a href="#">Términos de Servicio</a>
                <a href="#">Seguridad</a>
            </div>

        </div>
    </footer>

    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>

    <script>
        document.getElementById("year").textContent =
            new Date().getFullYear();
    </script>




        </div>
    </form>
</body>
</html>
