<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Label ID="bienvenidoLabel" runat="server" Text="Bienvenido" CssClass="titulo"></asp:Label>

    <div id="divWrapper">
        <asp:LinkButton ID="usuariosLinkButton" runat="server" OnClick="usuariosLinkButton_Click" CssClass="linkButton">Usuarios</asp:LinkButton>
        <asp:LinkButton ID="especialidadesLinkButton" runat="server" OnClick="especialidadesLinkButton_Click" CssClass="linkButton">Especialidades</asp:LinkButton>
        <asp:LinkButton ID="planesLinkButton" runat="server" OnClick="planesLinkButton_Click" CssClass="linkButton">Planes</asp:LinkButton>
        <asp:LinkButton ID="comisionesLinkButton" runat="server" OnClick="comisionesLinkButton_Click" CssClass="linkButton">Comisiones</asp:LinkButton>
        <asp:LinkButton ID="materiasLinkButton" runat="server" OnClick="materiasLinkButton_Click" CssClass="linkButton">Materias</asp:LinkButton>
        <asp:LinkButton ID="cursosLinkButton" runat="server" OnClick="cursosLinkButton_Click" CssClass="linkButton">Cursos</asp:LinkButton>      
    </div>

</asp:Content>

