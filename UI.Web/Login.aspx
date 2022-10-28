<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheets/StyleSheetLogin.css" rel="stylesheet" type="text/css" />
    <title>Academia - Ingreso</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Academia</h1>
        <div id="divWrapper">       
            <div id="divUsuario" class="divItems">
                <asp:Label ID="usuarioLabel" runat="server" Text="Usuario: "></asp:Label>
                <asp:TextBox ID="usuarioTextBox" runat="server" CssClass="txtBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="usuarioValidator" runat="server" ControlToValidate="usuarioTextBox"   
ErrorMessage="Ingrese nombre de usuario" ForeColor="Red" ValidationGroup="vg" CssClass="valida">*</asp:RequiredFieldValidator>
            </div>
            <div id="divPassword" class="divItems">
                <asp:Label ID="passwordLabel" type="password" runat="server" Text="Contraseña: "></asp:Label>
                <asp:TextBox ID="passwordTextBox" TextMode="Password" runat="server" CssClass="txtBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ControlToValidate="passwordTextBox"   
ErrorMessage="Ingrese contraseña" ForeColor="Red" ValidationGroup="vg" CssClass="valida">**</asp:RequiredFieldValidator>
            </div>
            <div id="divBoton" class="divItems">
                <asp:Button ID="ingresarButton" runat="server" Text="Ingresar" OnClick="ingresarButton_Click" />
            </div>
            <div id="divValidacion" class="divItems">
                <asp:ValidationSummary ID="formValidationSummary" runat="server" ForeColor="Red" ValidationGroup="vg" CssClass="valida"/>
                <asp:Label ID="mensajeLabel" runat="server" Text="" CssClass="valida"></asp:Label>
            </div>
        </div>
        
    </form>
</body>
</html>
