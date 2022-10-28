<%@ Page Title="Planes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="divGridContainer">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
             DataKeyNames="ID" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Plan" DataField="ID" />
                 <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                 <asp:BoundField HeaderText="Especialidad" DataField="IDEspecialidad" />
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
        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="descripcionValidator" runat="server" ControlToValidate="descripcionTextBox"   
ErrorMessage="La descripcion no puede estar vacía" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator> 
        <br />
        <asp:Label ID="idEspecialidadLabel" runat="server" Text="Especialidad: "></asp:Label>
        <asp:DropDownList ID="especialidadDropDown" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Descripcion" DataValueField="ID" Width="156px"></asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.EspecialidadLogic"></asp:ObjectDataSource>
        <!--<asp:TextBox ID="idEspecialidadTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="idEspecialidadValidator" runat="server" ControlToValidate="idEspecialidadTextBox"   
ErrorMessage="La especialidad no puede estar vacía" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator> 
        <asp:CompareValidator ID="idEspecialidadIntValidator" runat="server" ControlToValidate="idEspecialidadTextBox"
            Type="Integer" ErrorMessage="El id de especialidad debe ser un número" Operator="DataTypeCheck"
            ForeColor="Red" ValidationGroup="vg">*</asp:CompareValidator>-->
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>

        <asp:ValidationSummary ID="formValidationSummary" runat="server" ForeColor="Red" ValidationGroup="vg"/>
    
    </asp:Panel>
</div>

</asp:Content>
