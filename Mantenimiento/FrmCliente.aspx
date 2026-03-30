<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/MPMantenimiento.master" AutoEventWireup="true" CodeBehind="FrmCliente.aspx.cs" Inherits="SistemaDeFacturacionCS.Mantenimiento.FrmCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">

<h2>&nbsp Crear Clientes</h2>

<script language="JavaScript">
    <!--
        var nav4 = window.Event ? true : false;
        function acceptNum(evt) {
            // NOTE: Backspace = 8, Enter = 13, '0' = 48, '9' = 57, '.' = 46
            var key = nav4 ? evt.which : evt.keyCode;
            return (key <= 13 || (key >= 48 && key <= 57) || key == 46);
        }
    //-->
</script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:Panel ID="PnlBotonera" runat="server" BorderStyle="Solid" Width="138px" Height="639px" CssClass="PnlBotonera" BackImageUrl="~/Imagenes/Negra.png">
    <asp:ImageButton ID="ImgAceptar" runat="server" ImageUrl="~/Imagenes/Aceptar.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImgAceptar" Enabled="True" OnClick="ImgAceptar_Click" />
    <asp:ImageButton ID="ImbNuevo" runat="server" ImageUrl="~/Imagenes/Nuevo.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbNuevo" Enabled="False" OnClick="ImbNuevo_Click" />
    <asp:ImageButton ID="ImbCancelar" runat="server" ImageUrl="~/Imagenes/Cancelar.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbCancelar" OnClick="ImbCancelar_Click" />
    <asp:ImageButton ID="ImbBuscar" runat="server" ImageUrl="~/Imagenes/Buscar.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbBuscar" Enabled="True" OnClick="ImbBuscar_Click" />
    <asp:ImageButton ID="ImbModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbModificar" Enabled="False" OnClick="ImbModificar_Click" />
    <asp:ImageButton ID="ImbImprimir" runat="server" ImageUrl="~/Imagenes/Printer.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbPrinter" Enabled="False" />
</asp:Panel>

<asp:Panel ID="PnlMensaje" runat="server" CssClass="ImgBarraAzul" Width="784px" Height="50px">
    <asp:Image ID="ImgBarras" runat="server" ImageUrl="~/Imagenes/BarraAzul.png" CssClass="ImgBarraAzul" Width="852px" Height="50px" />
    <asp:Label ID="LblMensaje2" runat="server" Text="Mensaje:" Font-Bold="True" ForeColor="Black" CssClass="LblMensaje2"></asp:Label>
</asp:Panel>

<asp:Panel ID="PnlDatos" runat="server" BorderStyle="Solid" BorderColor="Black" Width="775px" Height="507px" CssClass="PnlDatos" BackImageUrl="~/Imagenes/Crema.jpg">

    <asp:Label ID="LblCodigo" runat="server" Text="Codigo.:" Font-Bold="True" CssClass="LblCodigoCliente"></asp:Label>
    <asp:Label ID="LblCliente" runat="server" Text="Tipo Cliente.:" Font-Bold="True" CssClass="LblTipoCliente"></asp:Label>
    <asp:Label ID="LblNombre" runat="server" Text="Nombre.:" Font-Bold="True" CssClass="LblNombreCliente"></asp:Label>

    <asp:TextBox ID="TxtCodigo" runat="server" CssClass="TxtCodigoCliente" ForeColor="#0066FF" AutoCompleteType="Disabled" font-size="Medium" Font-Bold="True" maxlength="4" Width="65px" ReadOnly="True"></asp:TextBox>
    <asp:DropDownList ID="DdlTipo" runat="server" CssClass="TxtTipoCliente" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="25" Width="154px" AutoPostBack="True"></asp:DropDownList>
    <asp:TextBox ID="TxtNombre" runat="server" CssClass="TxtNombreCliente" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="50" Width="154px"></asp:TextBox>

    <asp:Panel ID="PnlLinea1" runat="server" Width="769px" Height="0px" CssClass="PnlLinea1" BorderColor="Black" BorderStyle="Solid">
    </asp:Panel>

    <asp:Panel ID="PnlEmpresarial" runat="server" Width="388px" Height="242px" CssClass="PnlEmpresarial" BorderColor="Black" BorderStyle="Solid" Visible="true">
        <asp:Label ID="LblRNC" runat="server" Text="RNC.:" Font-Bold="True" CssClass="LblRNCCliente"></asp:Label>
        <asp:Label ID="LbLContacto" runat="server" Text="Contacto.:" Font-Bold="True" CssClass="LblContactoCliente"></asp:Label>
        <asp:Label ID="LblCargo" runat="server" Text="Cargo.:" Font-Bold="True" CssClass="LblCargoCliente"></asp:Label>
        <asp:Label ID="LblPagina" runat="server" Text="Pagina.:" Font-Bold="True" CssClass="LblPaginaCliente"></asp:Label>

        <div class="TxtRNCCliente" >
            <input ID="TxtRNCCliente" runat="server" style="width: 195px; height: 2.4%; font-weight: bold; font-size: medium; color:#0066FF" title="Introduzca el RNC de la compañia" OnFocus = " this . style . borderColor = 'black' " OnBlur = " this . style . borderColor = '' "  onKeyPress="return acceptNum(event)" type="text" name="RNC" placeholder="" onkeyup="
                var RNC = this.value;
                if (RNC.match(/^\d{3}$/) !== null) {
                    this.value = RNC + '-';
                } else if (RNC.match(/^\d{3}\-\d{5}$/) !== null) {
                    this.value = RNC + '-';
                }" maxlength="11" autocomplete="off" >
        </div>

        <asp:TextBox ID="TxtContacto" runat="server" CssClass="TxtContactoCliente" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="50" Width="195px"></asp:TextBox>
        <asp:TextBox ID="TxtCargo" runat="server" CssClass="TxtCargoCliente" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="50" Width="195px"></asp:TextBox>
        <asp:TextBox ID="TxtPagina" runat="server" CssClass="TxtPaginaCliente" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="50" Width="195px"></asp:TextBox>
    </asp:Panel>

    <asp:Panel ID="PnlPersonal" runat="server" Width="388px" Height="242px" CssClass="PnlEmpresarial" BorderColor="Black" BorderStyle="Solid" Visible="false">
        <asp:Label ID="LblApellido" runat="server" Text="Apellido.:" Font-Bold="True" CssClass="LblRNCCliente"></asp:Label>
        <asp:Label ID="LblCedula" runat="server" Text="Cedula.:" Font-Bold="True" CssClass="LblContactoCliente"></asp:Label>

        <asp:TextBox ID="TxtApellido" runat="server" CssClass="TxtRNCCliente" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="50" Width="195px"></asp:TextBox>

        <div class="TxtCedulaCliente" >
            <input ID="TxtCedulaCliente" runat="server" style="width: 195px; height: 2.4%; font-weight: bold; font-size: medium; color:#0066FF" title="Introduzca la Cedula de la persona" OnFocus = " this . style . borderColor = 'black' " OnBlur = " this . style . borderColor = '' "  onKeyPress="return acceptNum(event)" type="text" name="RNC" placeholder="" onkeyup="
                var Cedula = this.value;
                if (Cedula.match(/^\d{3}$/) !== null) {
                    this.value = Cedula + '-';
                } else if (Cedula.match(/^\d{3}\-\d{7}$/) !== null) {
                    this.value = Cedula + '-';
                }" maxlength="13" autocomplete="off" >
        </div>
    </asp:Panel>

    <asp:Panel ID="PnlDatosGeneral" runat="server" Width="379px" Height="242px" CssClass="PnlDatosGeneral" BorderColor="Black" BorderStyle="Solid">
        <asp:Label ID="LblDireccion" runat="server" Text="Direccion.:" Font-Bold="True" CssClass="LblRNCCliente"></asp:Label>
        <asp:Label ID="LblPais" runat="server" Text="Pais.:" Font-Bold="True" CssClass="LblContactoCliente"></asp:Label>
        <asp:Label ID="LblProvincia" runat="server" Text="Provincia.:" Font-Bold="True" CssClass="LblCargoCliente"></asp:Label>
        <asp:Label ID="LblTelefono" runat="server" Text="Telefono.:" Font-Bold="True" CssClass="LblPaginaCliente"></asp:Label>
        <asp:Label ID="LblCelular" runat="server" Text="Celular.:" Font-Bold="True" CssClass="LblCelularCliente"></asp:Label>
        <asp:Label ID="LblCorreo" runat="server" Text="Correo.:" Font-Bold="True" CssClass="LblCorreoCliente"></asp:Label>

        <asp:TextBox ID="TxtDireccion" runat="server" CssClass="TxtRNCCliente" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="50" Width="195px"></asp:TextBox>
        <asp:DropDownList ID="DdlPais" runat="server" ToolTip="Seleccione el pais deseado" ForeColor="#0066FF" Font-Bold="True" Enabled="True" Font-Size="Medium" AutoPostBack="true" TabIndex="10" CssClass="DdlPais" DataTextField="Pai_Nombre" DataValueField="Id_Pais" OnSelectedIndexChanged="DdlPais_SelectedIndexChanged" Width="203px"></asp:DropDownList>
        <asp:DropDownList ID="DdlProvincia" runat="server" ToolTip="Seleccione la pronvincia del pais" ForeColor="#0066FF" Font-Bold="True" Enabled="True" Font-Size="Medium" AutoPostBack="False" TabIndex="10" CssClass="TxtCargoCliente" DataTextField="Pro_Nombre" DataValueField="Id_Pais" Width="203px"></asp:DropDownList>

        <asp:TextBox ID="TextBox1" runat="server" ForeColor="#0066FF" Font-Bold="True" Font-Size="Medium" CssClass="DdlPais" Width="170px" Height="15px" Visible="False" ReadOnly="True"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" ForeColor="#0066FF" Font-Bold="True" Font-Size="Medium" CssClass="TxtCargoCliente" Width="170px" Height="15px" Visible="False" ReadOnly="True"></asp:TextBox>

        <div class="TxtTelefonoCliente" >
            <input ID="TxtTelefono" runat="server" style="width : 195px; height: 2.4%; font-weight: bold; font-size: medium; color:#0066FF" title="Introduzca el telefono de la compañia" OnFocus = " this . style . borderColor = 'black' " onKeyPress="return acceptNum(event)" type="text" name="Phone" placeholder="" onkeyup="
                var Phone = this.value;
                if (Phone.match(/^\d{3}$/) !== null) {
                this.value = Phone + '-';
                } else if (Phone.match(/^\d{3}\-\d{3}$/) !== null) {
                this.value = Phone + '-';
                }" maxlength="12" autocomplete="off" >
        </div>

        <div class="TxtCelularCliente" >
            <input ID="TxtCelular" runat="server" style="width : 195px; height: 2.4%; font-weight: bold; font-size: medium; color:#0066FF" title="Introduzca el Celular de contacto" OnFocus = " this . style . borderColor = 'black' " onKeyPress="return acceptNum(event)" type="text" name="Phone" placeholder="" onkeyup="
                var Phone = this.value;
                if (Phone.match(/^\d{3}$/) !== null) {
                this.value = Phone + '-';
                } else if (Phone.match(/^\d{3}\-\d{3}$/) !== null) {
                this.value = Phone + '-';
                }" maxlength="12" autocomplete="off" >
        </div>

        <asp:TextBox ID="TxtCorreo" runat="server" CssClass="TxtCorreoCliente" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="50" Width="195px"></asp:TextBox>
    </asp:Panel>

</asp:Panel>

<asp:Panel ID="PnlGridview" runat="server" BorderStyle="Outset" Width="764px" CssClass="PnlPanelCliente" Height="204px" ScrollBars="Auto" ToolTip="Buscar Registro">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="3" RowStyle-Wrap="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" Wrap="False" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" ForeColor="White" Font-Bold="True" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
        <Columns>
            <asp:CommandField ButtonType="Image" ShowselectButton="True" SelectImageUrl="../Imagenes/Seleccion.png" />
            <asp:BoundField DataField="Cli_Codigo" HeaderText="Codigo" />
            <asp:BoundField DataField="Cli_Tipo" HeaderText="Tipo Cliente" />
            <asp:BoundField DataField="Cli_Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Cli_RNC" HeaderText="RNC" />
            <asp:BoundField DataField="Cli_Contacto" HeaderText="Contacto" />
            <asp:BoundField DataField="Cli_Cargo" HeaderText="Cargo" />
            <asp:BoundField DataField="Cli_Pagina" HeaderText="Pagina" />
            <asp:BoundField DataField="Cli_Direccion" HeaderText="Direccion" />
            <asp:BoundField DataField="Cli_Pais" HeaderText="Pais" />
            <asp:BoundField DataField="Cli_Provincia" HeaderText="Provincia" />
            <asp:BoundField DataField="Cli_Telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="Cli_Celular" HeaderText="Celular" />
            <asp:BoundField DataField="Cli_Correo" HeaderText="Correo" />
            <asp:BoundField DataField="Cli_Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="Cli_Cedula" HeaderText="Cedula" />
        </Columns>
    </asp:GridView>
</asp:Panel>

<asp:Panel ID="PnlCuadroGridview" runat="server" BorderStyle="Solid" Width="768px" CssClass="PnlPanel2Clientes" Height="206px" ScrollBars="Auto" BorderWidth="1px" BackColor="#999999" ToolTip="Buscar Registros">
</asp:Panel>

<asp:Timer ID="Timer1" runat="server" Interval="4000" Enabled="False" OnTick="Timer1_Tick"></asp:Timer>

</asp:Content>