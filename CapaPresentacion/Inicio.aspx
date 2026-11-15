
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SoporteTecnico.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema de Soporte Técnico</title>

    <style>
        /* Diseño general de la pagina */
        body {
            font-family: Arial;
            background-color: #eef2f6;
            margin: 0;
            padding: 0;
        }

        /* Encabezado principal */
        .encabezado {
            background-color: #24364b;
            color: white;
            text-align: center;
            padding: 30px;
        }

        /* Contenedor de los botones */
        .contenedor {
            text-align: center;
            margin-top: 60px;
        }

        /* Estilo de los botones */
        .boton {
            background-color: #315d85;
            color: white;
            border: none;
            padding: 15px 25px;
            margin: 15px;
            font-size: 16px;
            cursor: pointer;
            border-radius: 5px;
        }

        /* Efecto al pasar el mouse */
        .boton:hover {
            background-color: #1d405f;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="encabezado">
            <h1>Sistema de Soporte Técnico</h1>
            <p>Administración de usuarios y equipos</p>
        </div>

        <div class="contenedor">

            <h2>Bienvenido</h2>
            <p>Seleccione el módulo que desea administrar.</p>

            <asp:Button ID="btnUsuarios" runat="server"
                Text="Administrar Usuarios"
                CssClass="boton"
                PostBackUrl="~/CapaPresentacion/Usuarios.aspx" />

            <asp:Button ID="btnEquipos" runat="server"
                Text="Administrar Equipos"
                CssClass="boton"
                PostBackUrl="~/CapaPresentacion/Equipos.aspx" />

        </div>

    </form>
</body>
</html>
