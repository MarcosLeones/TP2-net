<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                 <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                 <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                 <asp:BoundField HeaderText="Email" DataField="Email" />
                 <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                 <asp:BoundField HeaderText="Habiltado" DataField="Habilitado" />
                 <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>  
    </asp:Panel>

    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server">

        <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="nombreValidator" runat="server" ControlToValidate="nombreTextBox"   
ErrorMessage="El nombre no puede estar vacío" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator> 
        <br />

        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="apellidoValidator" runat="server" ControlToValidate="apellidoTextBox"   
ErrorMessage="El apellido no puede estar vacío" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator> 
        <br />

        <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="emailValidator" runat="server" ControlToValidate="emailTextBox" 
ErrorMessage="E-Mail inválido" ForeColor="Red" ValidationGroup="vg"
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        <br /> 
        
        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
        <asp:CheckBox ID="habilitadoCheckBox" runat="server"></asp:CheckBox>
        <br />

        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="nombreUsuarioValidator" runat="server" ControlToValidate="nombreUsuarioTextBox"   
ErrorMessage="El nombre de usuario no puede estar vacío" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator> 
        <br />

        <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
        <asp:TextBox ID="claveTextBox" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="claveValidator" runat="server"
        ControlToValidate = "claveTextBox" ValidationExpression = "^[\s\S]{8,}$"
        ErrorMessage="La clave debe contener al menos 8 caracteres" ForeColor="Red" ValidationGroup="vg">*</asp:RegularExpressionValidator>
        <br />

        <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
        <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="repetirClaveValidator" runat="server" ControlToValidate="repetirClaveTextBox" 
           ControlToCompare="claveTextBox" Type="String" 
   ErrorMessage="La claves no coinciden" ForeColor="Red" ValidationGroup="vg">*</asp:CompareValidator>
        <br />

        <asp:Panel ID="formActionsPanel" runat="server">  
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>

        <asp:ValidationSummary ID="formValidationSummary" runat="server" ForeColor="Red" ValidationGroup="vg"/>  

    </asp:Panel>

</asp:Content>