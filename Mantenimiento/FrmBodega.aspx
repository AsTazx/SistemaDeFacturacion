<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/MPMantenimiento.master" AutoEventWireup="true" CodeBehind="FrmBodega.aspx.cs" Inherits="SistemaDeFacturacionCS.Mantenimiento.FrmBodega" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
<h2>&nbsp Crear Bodegas</h2>

<asp:Panel ID="PnlBotonera" runat="server" BorderStyle="Solid" Width="138px" Height="639px" CssClass="PnlBotonera" BackImageUrl="~/Imagenes/Negra.png">
    <asp:ImageButton ID="ImgAceptar" runat="server" ImageUrl="~/Imagenes/Aceptar.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImgAceptar" Enabled="true" Onclick="ImgAceptar_Click"/>
    <asp:ImageButton ID="ImbNuevo" runat="server" ImageUrl="~/Imagenes/Nuevo.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbNuevo" Enabled="false" Onclick="ImbNuevo_Click"/>
    <asp:ImageButton ID="ImbCancelar" runat="server" ImageUrl="~/Imagenes/Cancelar.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbCancelar" OnClick="ImbCancelar_Click"/>
    <asp:ImageButton ID="ImbBuscar" runat="server" ImageUrl="~/Imagenes/Buscar.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbBuscar" Enabled="true" OnClick="ImbBuscar_Click"/>
    <asp:ImageButton ID="ImbModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbModificar" Enabled="false" OnClick="ImbModificar_Click"/>
    <asp:ImageButton ID="ImbImprimir" runat="server" ImageUrl="~/Imagenes/Printer.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbPrinter" Enabled="False"/>
</asp:Panel>


    <asp:Panel ID="PnlMensaje" runat="server" CssClass="ImgBarraAzul" Width="784px" Height="50px">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Font-Size="25px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" Wrap="False" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="../Imagenes/Seleccion.png" ShowSelectButton="True" />
                <asp:BoundField DataField="Bod_Codigo" HeaderText="Codigo" />
                <asp:BoundField DataField="Bod_Referencia" HeaderText="Referencia" />
                <asp:BoundField DataField="Bod_Descripcion" HeaderText="Descripcion" />
            </Columns>
        </asp:GridView>
        <asp:Image ID="ImgBarras" runat="server" ImageUrl="~/Imagenes/BarraAzul.png" CssClass="ImgBarraAzul" Width="852px" Height="50px"/>
        <asp:Label ID="LblMensaje2" runat="server" Text="Mensaje.:" Font-Bold="true" ForeColor="Black" CssClass="LblMensaje2"></asp:Label>
    </asp:Panel>

    <asp:Panel ID="PnlDatos" runat="server" BorderStyle="Solid" BorderColor="Black" Width="775px" Height="507px" CssClass="PnlDatos" BackImageUrl="~/Imagenes/Crema.jp">
        <asp:Label ID="LblCodigo" runat="server" Text="Codigo.:" Font-Bold="true" CssClass="LblCodigo"></asp:Label>
        <asp:Label ID="LblReferencia" runat="server" Text="Referencia.:" Font-Bold="true" CssClass="LblReferencia"></asp:Label>
        <asp:Label ID="LblDescripcion" runat="server" Text="Descripcion.:" Font-Bold="true" CssClass="LblDescripcion"></asp:Label>
        <asp:TextBox ID="TxtCodigo" runat="server" CssClass="TxtCodigo" ForeColor="#0066FF" AutoCompleteType="Disabled" Font-Size="Medium" Font-Bold="true" MaxLength="4" Width="65px" ReadOnly="true"></asp:TextBox>
        <asp:TextBox ID="TxtReferencia" runat="server" CssClass="TxtReferencia" ForeColor="#0066FF" Font-Bold="true" AutoCompleteType="Disabled" font-size="Medium" maxlength="25"></asp:TextBox>
        <asp:TextBox ID="TxtDescripcion" runat="server" ForeColor="#0066FF" Font-Bold="true" AutoCompleteType="Disabled" Font-Size="Medium" MaxLength="50"></asp:TextBox>
    </asp:Panel>

    <asp:Panel ID="PnlGridview" runat="server" BorderStyle="Outset" Width="764px" CssClass="PnlPanel" Height="216px" ScrollBars="Auto" ToolTip="Buscar Registro">
</asp:Panel>


 <asp:Panel ID="PnlCuadroGridView" runat="server" BorderStyle="Solid" Width="768px" CssClass="PnlPanel2" Height="218px" ScrollBars="Auto" ToolTip="Buscar Registro"></asp:Panel>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="4000" Enabled="False" OnTick="Timer1_Tick"></asp:Timer>

    </asp:content>

        