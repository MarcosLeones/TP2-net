<%@ Page Title="Materias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divGridContainer">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
             DataKeyNames="ID" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                 <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                 <asp:BoundField HeaderText="HS semanales" DataField="HSSemanales" />
                 <asp:BoundField HeaderText="HS totales" DataField="HSTotales" />
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
        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descripcionTextBox" runat="server" Width="198px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="descripcionValidator" runat="server" ControlToValidate="descripcionTextBox"   
ErrorMessage="La descripcion no puede estar vacía" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator> 
        <br />

        <asp:Label ID="hsSemanalesLabel" runat="server" Text="Horas Semanales: "></asp:Label>
        <asp:TextBox ID="hsSemanalesTextBox" runat="server" Width="152px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="hsSemanalesValidator" runat="server" ControlToValidate="hsSemanalesTextBox"   
ErrorMessage="Igrese las horas semanales" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator> 
        <asp:CompareValidator ID="hsSemanalesIntValidator" runat="server" ControlToValidate="hsSemanalesTextBox"
            Type="Integer" ErrorMessage="Las horas semanales deben ser un número entero" Operator="DataTypeCheck"
            ForeColor="Red" ValidationGroup="vg">*</asp:CompareValidator>
        <br />

        <asp:Label ID="hsTotalesLabel" runat="server" Text="Horas Totales: "></asp:Label>
        <asp:TextBox ID="hsTotalesTextBox" runat="server" Width="178px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="hsTotalesValidator" runat="server" ControlToValidate="hsTotalesTextBox"   
ErrorMessage="Igrese las horas totales" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator> 
        <asp:CompareValidator ID="hsTotalesIntValidator" runat="server" ControlToValidate="hsTotalesTextBox"
            Type="Integer" ErrorMessage="Las horas totales deben ser un número entero" Operator="DataTypeCheck"
            ForeColor="Red" ValidationGroup="vg">*</asp:CompareValidator>
        <br />

        <asp:Label ID="idPlanLabel" runat="server" Text="Plan: "></asp:Label>
        <asp:DropDownList ID="planDropDown" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Descripcion" DataValueField="ID" Width="266px"></asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.PlanLogic"></asp:ObjectDataSource>
        <!--<asp:TextBox ID="idPlanTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="idPlanValidator" runat="server" ControlToValidate="idPlanTextBox"   
ErrorMessage="El plan no puede estar vacío" ForeColor="Red" ValidationGroup="vg">*</asp:RequiredFieldValidator>        
        <asp:CompareValidator ID="idPlanIntValidator" runat="server" ControlToValidate="idPlanTextBox"
            Type="Integer" ErrorMessage="El id del plan ser un número entero" Operator="DataTypeCheck"
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
