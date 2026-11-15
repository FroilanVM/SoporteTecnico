
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="SoporteTecnico.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Administración de Usuarios</title>

    <style>
        /* Diseño general de la página */
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
            padding: 25px;
        }

        .encabezado h1 {
            margin: 0;
        }

        .encabezado p {
            margin-bottom: 0;
        }

        /* Tarjeta del formulario */
        .contenedor {
            background-color: white;
            width: 450px;
            margin: 40px auto;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 3px 10px rgba(0,0,0,0.12);
        }

        .contenedor h2 {
            text-align: center;
            color: #24364b;
            margin-top: 0;
        }

        /* Etiquetas de los campos */
        .campo {
            margin-bottom: 18px;
        }

        .campo label {
            display: block;
            margin-bottom: 7px;
            color: #333;
            font-weight: bold;
        }

        /* Cajas de texto */
        .entrada {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
            font-size: 14px;
        }

        .entrada:focus {
            outline: none;
            border-color: #315d85;
        }

        /* Botones */
        .botones {
            text-align: center;
            margin-top: 25px;
        }

        .boton {
            color: white;
            border: none;
            padding: 11px 16px;
            margin: 5px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 14px;
        }

        .guardar {
            background-color: #287a4b;
        }

        .modificar {
            background-color: #315d85;
        }

        .eliminar {
            background-color: #bd3d3d;
        }

        .consultar {
            background-color: #65758b;
        }

        .boton:hover {
            opacity: 0.85;
        }

        /* Mensajes del sistema */
        .mensaje {
            display: block;
            text-align: center;
            margin-top: 20px;
            font-weight: bold;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="encabezado">
            <h1>Administración de Usuarios</h1>
            <p>Registro y mantenimiento de usuarios del sistema</p>
        </div>

        <div class="contenedor">

            <h2>Datos del Usuario</h2>

            <div class="campo">
                <label>Identificación:</label>
                <asp:TextBox ID="tUsuarioID" runat="server"
                    CssClass="entrada"></asp:TextBox>
            </div>

            <div class="campo">
                <label>Nombre:</label>
                <asp:TextBox ID="tNombre" runat="server"
                    CssClass="entrada"></asp:TextBox>
            </div>

            <div class="campo">
                <label>Correo electrónico:</label>
                <asp:TextBox ID="tCorreo" runat="server"
                    CssClass="entrada"></asp:TextBox>
            </div>

            <div class="campo">
                <label>Teléfono:</label>
                <asp:TextBox ID="tTelefono" runat="server"
                    CssClass="entrada"></asp:TextBox>
            </div>

            <div class="botones">

                <asp:Button ID="bGuardar" runat="server"
                    Text="Guardar"
                    CssClass="boton guardar"
                    OnClick="bGuardar_Click" />

                <asp:Button ID="bModificar" runat="server"
                    Text="Modificar"
                    CssClass="boton modificar"
                    OnClick="bModificar_Click" />

                <asp:Button ID="bEliminar" runat="server"
                    Text="Eliminar"
                    CssClass="boton eliminar"
                    OnClick="bEliminar_Click" />

                <asp:Button ID="bConsultar" runat="server"
                    Text="Consultar"
                    CssClass="boton consultar"
                    OnClick="bConsultar_Click" />

            </div>

             <div class="botones">
                <asp:Button ID="bVolver" runat="server"
                    Text="Volver al menú principal"
                    CssClass="boton consultar"
                    PostBackUrl="~/CapaPresentacion/Inicio.aspx" />
            </div>

            <asp:Label ID="lMensaje" runat="server"
                CssClass="mensaje"></asp:Label>

           </div>

    </form>
</body>
</html>
