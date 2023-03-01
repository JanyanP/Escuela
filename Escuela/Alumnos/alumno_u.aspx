<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_u.aspx.cs" Inherits="Escuela.Alumnos.alumno_u" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>Matricula: </td>
                    <td>
                        <asp:Label ID="lblMatricula" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Nombre: </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Fecha de Nacimiento: </td>
                    <td>
                        <asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Semestre: </td>
                    <td>
                        <asp:TextBox ID="txtSemestre" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Facultad: </td>
                    <td>
                        <asp:DropDownList ID="ddlFacultad" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Estado:</td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Ciudad:</td>
                    <td>
                        <asp:DropDownList ID="ddlCiudad" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
