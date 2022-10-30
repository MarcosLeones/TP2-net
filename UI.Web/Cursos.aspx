<%@ Page Title="Cursos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divGridContainer">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                 <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                 <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
                 <asp:BoundField HeaderText="Año" DataField="AnioCalendario" />
                 <asp:BoundField HeaderText="Comision" DataField="IDComision" />
                 <asp:BoundField HeaderText="Materia" DataField="IDMateria" />
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

        <asp:Label ID="descripcionLabel" runat="server" Text="Descripción: "></asp:Label>
        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="descripcionValidator" runat="server" ControlToValidate="descripcionTextBox"   
ErrorMessage="La descripción no puede estar vacía" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator>
        <br />

        <asp:Label ID="cupoLabel" runat="server" Text="Cupo: "></asp:Label>
        <asp:TextBox ID="cupoTextBox" runat="server" Width="214px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="cupoValidator" runat="server"         
        ControlToValidate = "cupoTextBox" ValidationExpression = "^[0-9]+$"
        ErrorMessage="El cupo debe ser un numero" ForeColor="Red" ValidationGroup="vg">*</asp:RegularExpressionValidator>
        <br />

        <asp:Label ID="anioLabel" runat="server" Text="Año: "></asp:Label>
        <asp:TextBox ID="anioTextBox" runat="server" Width="220px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="anioValidator" runat="server" ControlToValidate="anioTextBox"   
        ErrorMessage="El anio no puede estar vacío" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator> 
        <br />


        <asp:Label ID="materiaLabel" runat="server" Text="Materia: "></asp:Label>
        <asp:DropDownList ID="materiaDropDown" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Descripcion" DataValueField="ID" Height="16px" Width="199px"></asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.MateriaLogic"></asp:ObjectDataSource>
        <!--<asp:TextBox ID="materiaTextBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="materiaValidator" runat="server"         
        ControlToValidate = "materiaTextBox" ValidationExpression = "^[0-9]+$"
        ErrorMessage="El id de la materia debe ser un numero" ForeColor="Red" ValidationGroup="vg">*</asp:RegularExpressionValidator>
        -->
        <br />

        <asp:Label ID="ComisionLabel" runat="server" Text="Comisión: "></asp:Label>
        <asp:DropDownList ID="comisionDropDown" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Descripcion" DataValueField="ID" Height="17px" Width="181px"></asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.ComisionLogic"></asp:ObjectDataSource>
        <!--<asp:TextBox ID="comisionTextBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="comisionValidator" runat="server"         
        ControlToValidate = "comisionTextBox" ValidationExpression = "^[0-9]+$"
        ErrorMessage="El id de la comision debe ser un numero" ForeColor="Red" ValidationGroup="vg">*</asp:RegularExpressionValidator>
        -->
        <br />

        <asp:Panel ID="formActionsPanel" runat="server">  
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>

        <asp:ValidationSummary ID="formValidationSummary" runat="server" ForeColor="Red" ValidationGroup="vg"/>  

    </asp:Panel>
</div>

</asp:Content>