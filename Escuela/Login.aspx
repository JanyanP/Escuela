﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Escuela.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="formLogin" runat="server">
        <div id="imgLogin"></div>
        <div>
            <table>
                <tr>
                    <td>Nombre de usuario:</td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Contraseña:</td>
                    <td>
                        <asp:TextBox ID="txtContraseña" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
