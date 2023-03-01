<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_s.aspx.cs" Inherits="Escuela.Alumnos.alumno_s" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="grd_alumnos" AutoGenerateColumns="false" runat="server" OnRowCommand="grd_alumnos_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px"
                        CommandName="Editar" CommandArgument='<%#Eval("matricula")%>'
                        />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px"
                        CommandName="Eliminar" CommandArgument='<%#Eval("matricula")%>'
                        />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Matrícula" DataField="matricula"/>
            <asp:BoundField HeaderText="Nombre" DataField="nombre"/>
            <asp:BoundField HeaderText="Fecha de nacimiento" DataField="fechaNacimiento" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField HeaderText="Semestre" DataField="semestre"/>
            <asp:BoundField HeaderText="Facultad" DataField="nombreFacultad"/>
            <asp:BoundField HeaderText="Ciudad" DataField="nombreCiudad"/>
        </Columns>
    </asp:GridView>

</asp:Content>
