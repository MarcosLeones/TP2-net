<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                 <asp:BoundField HeaderText="Año Especialidad" DataField="AnioEspecialidad" />
                 <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                 <asp:BoundField HeaderText="Plan" DataField="IDPlan" />
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

        <asp:Label ID="anioLabel" runat="server" Text="Año Especialidad: "></asp:Label>
        <asp:TextBox ID="anioTextBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="anioNroValidator" runat="server"         
        ControlToValidate = "anioTextBox" ValidationExpression = "^[0-9]+$"
        ErrorMessage="El año debe ser un numero" ForeColor="Red" ValidationGroup="vg">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="anioValidator" runat="server" ControlToValidate="anioTextBox"   
        ErrorMessage="El anio no puede estar vacío" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator> 
        <br />


        <asp:Label ID="descripcionLabel" runat="server" Text="Descripción: "></asp:Label>
        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="descripcionValidator" runat="server" ControlToValidate="descripcionTextBox"   
        ErrorMessage="La descripción no puede estar vacía" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
        <br />

        <asp:Label ID="planLabel" runat="server" Text="Plan: "></asp:Label>
        <asp:DropDownList id="planList" OnSelectedIndexChanged="Selection_Change" runat="server"/>
        <br />

        <asp:Panel ID="formActionsPanel" runat="server">  
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>

        <asp:ValidationSummary ID="formValidationSummary" runat="server" ForeColor="Red" ValidationGroup="vg"/>  

    </asp:Panel>


</asp:Content>
