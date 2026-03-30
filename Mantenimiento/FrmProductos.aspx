<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/MPMantenimiento.master" AutoEventWireup="true" CodeBehind="FrmProductos.aspx.cs" Inherits="SistemaDeFacturacionCS.Mantenimiento.FrmProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
<h2>&nbsp Crear Productos</h2>

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

<asp:Panel ID="PnlBotonera" runat="server" BorderStyle="Solid" Width="138px" Height="639px" CssClass="PnlBotonera" BackImageUrl="~/Imagenes/Negra.png">
<asp:ImageButton ID="ImgAceptar" runat="server" ImageUrl="~/Imagenes/Aceptar.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImgAceptar" Enabled="true" OnClick="ImgAceptar_Click" />
<asp:ImageButton ID="ImbNuevo" runat="server" ImageUrl="~/Imagenes/Nuevo.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbNuevo" Enabled="true" OnClick="ImbNuevo_Click"/>
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
<asp:Panel ID="PnlIdentificacion" runat="server" BorderColor="#CC0000" Width="760px" CssClass="PnlIdentificacion" Height="28px" BorderStyle="Ridge">
<asp:Label ID="LblCodigo" runat="server" Text="Codigo.:" Font-Bold="True" CssClass="LblCodigoProducto"></asp:Label>
<asp:TextBox ID="TxtCodigo" runat="server" ForeColor="#0066FF" AutoCompleteType="Disabled" font-size="Medium" Font-Bold="True" Width="215px" CssClass="TxtCodigoProducto"></asp:TextBox>
<asp:Label ID="LblNombreProducto" runat="server" Text="Nombre Producto.:" Font-Bold="True" CssClass="LblNombreProducto"></asp:Label>
<asp:TextBox ID="TxtNombreProducto" runat="server" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="50" CssClass="TxtNombreProducto" Width="300px"></asp:TextBox>

</asp:Panel>
    </asp:Panel>

<asp:Label ID="LblPrecioLetrero" runat="server" Text="Precios / Costos" Font-Bold="True" CssClass="LblPrecioLetrero" ForeColor="Fuchsia"></asp:Label>

<asp:Panel ID="PnlPrecio" runat="server" CssClass="PnlPrecio" Width="263px" Height="79px" BorderStyle="Ridge">
<asp:Label ID="LblPrecioCompra" runat="server" Text="Precio Compra RD$.:" Font-Bold="True" CssClass="LblPrecioCompra"></asp:Label>
<asp:Label ID="LblPrecioCompraUS" runat="server" Text="Precio Compra US$.:" Font-Bold="True" CssClass="LblPrecioCompraUS"></asp:Label>
<asp:TextBox ID="TxtPrecioCompra" runat="server" CssClass="TxtPrecioCompra" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="50" Text="0.00" Width="100px" OnTextChanged="TxtPrecioCompra_TextChanged" AutoPostBack="True" onKeyPress="return acceptNum(event)"></asp:TextBox>
<asp:TextBox ID="TxtPrecioCompraUS" runat="server" CssClass="TxtPrecioCompraUS" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="50" Text="0.00" Width="100px" AutoPostBack="True" onKeyPress="return acceptNum(event)" OnTextChanged="TxtPrecioCompraUS_TextChanged"></asp:TextBox>
</asp:Panel>

<asp:Panel ID="PnlStatus" runat="server" CssClass="PnlStatus" Width="410px" Height="23px" BorderStyle="Ridge">
<asp:Label ID="LblStatus" runat="server" Text="Producto esta Activo.:" Font-Bold="True" CssClass="LblPrecioCompra"></asp:Label>
<asp:Label ID="LblAplicarItsbis" runat="server" Text="Aplicar Itebis.:" Font-Bold="True" CssClass="LblAplicarItbis"></asp:Label>
<asp:CheckBox ID="ChbStatus" runat="server" CssClass="ChbStatus" Checked="True" />
<asp:CheckBox ID="ChbAplicarItbis" runat="server" CssClass="ChbAplicarItbis" />
</asp:Panel>

<asp:Panel ID="PnlProducto" runat="server" CssClass="PnlProducto" Width="410px" Height="80px" BorderStyle="Ridge">
<asp:Label ID="LblProducto" runat="server" Text="El Producto es.:" Font-Bold="True" CssClass="LblPrecioCompra"></asp:Label>
<asp:RadioButton ID="RbtFisico" runat="server" Text="Fisico" CssClass="ChbFisico" Checked="True" AutoPostBack="true" OnCheckedChanged="RbtFisico_CheckedChanged" />
<asp:RadioButton ID="RbtServicio" runat="server" Text="Servicio" CssClass="ChbServicio" AutoPostBack="true" OnCheckedChanged="RbtServicio_CheckedChanged" />

<asp:RadioButton ID="RbtOcasional" runat="server" Text="Ocasional" CssClass="ChbOcasional" AutoPostBack="true" OnCheckedChanged="RbtOcasional_CheckedChanged" />
<asp:Label ID="LblCantidadInicial" runat="server" Text="Cantidad Inicial.:" Font-Bold="True" CssClass="LblCantidadInicial"></asp:Label>
<asp:TextBox ID="TxtCantidadInicial" runat="server" CssClass="TxtCantidadInicial" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="50" Text="0.00" Width="100px" AutoPostBack="True" onKeyPress="return acceptNum(event)" OnTextChanged="TxtCantidadInicial_TextChanged"></asp:TextBox>
</asp:Panel>

<asp:Panel ID="PnlBodegas" runat="server" CssClass="PnlBodegas" Width="138px" Height="79px" BorderStyle="Ridge">
<asp:Label ID="LblBodega" runat="server" Text="Bodega" Font-Bold="True" CssClass="LblBodegas"></asp:Label>
<asp:DropDownList ID="DdlBodega" runat="server" Width="130px" CssClass="DdlBodega" ForeColor="#0066FF" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
<asp:Label ID="LblUbicacion" runat="server" Text="Ubicacion Fisica" Font-Bold="True" CssClass="LblUbicacion"></asp:Label>

<asp:DropDownList ID="DdlUbicacion" runat="server" Width="130px" CssClass="DdlUbicacion" ForeColor="#0066FF" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
</asp:Panel>

<asp:Panel ID="PnlCategoria" runat="server" CssClass="PnlCategoria" Width="338px" Height="79px" BorderStyle="Ridge">
<asp:Label ID="LblCategoria" runat="server" Text="Categoria Producto.:" Font-Bold="True" CssClass="LblPrecioCompra"></asp:Label>
<asp:DropDownList ID="DdlCategoria" runat="server" Width="130px" CssClass="DdlCategoria" ForeColor="#0066FF" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
<asp:Label ID="LblSubCategoria" runat="server" Text="Subcategoria.:" Font-Bold="True" CssClass="LblSubCategoria"></asp:Label>
<asp:DropDownList ID="DdlSubCategoria" runat="server" Width="130px" CssClass="DdlSubCategoria" ForeColor="#0066FF" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
<asp:Label ID="LblReferencia" runat="server" Text="Referencia.:" Font-Bold="True" CssClass="LblReferenvia"></asp:Label>

<asp:TextBox ID="TxtReferencia" runat="server" CssClass="TxtReferenciaProducto" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="25" Width="122px"></asp:TextBox>
</asp:Panel>

<asp:Panel ID="PnlFormaVenta" runat="server" CssClass="PnlFormaVenta" Width="338px" Height="112px" BorderStyle="Ridge">
<asp:Label ID="LblSeVende" runat="server" Text="Se Vende Por.:" Font-Bold="True" CssClass="LblPrecioCompra"></asp:Label>
<asp:DropDownList ID="DdlSeVende" runat="server" Width="130px" CssClass="DdlCategoria" ForeColor="#0066FF" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
<asp:Label ID="LblContiene" runat="server" Text="Y Contiene.:" Font-Bold="True" CssClass="LblSubCategoria"></asp:Label>
<asp:TextBox ID="TxtContiene" runat="server" CssClass="TxtContiene" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="50" Text="0.00" Width="100px" AutoPostBack="True" onKeyPress="return acceptNum(event)" OnTextChanged="TxtContiene_TextChanged"></asp:TextBox>
<asp:Label ID="LblUnid" runat="server" Text="Unid (s)" CssClass="LblUnid"></asp:Label>
<asp:Label ID="LblSeCompra" runat="server" Text="Se Compra Por.:" Font-Bold="True" CssClass="LblSeCompra"></asp:Label>
<asp:DropDownList ID="DdlSeCompra" runat="server" Width="130px" CssClass="DdlSeCompra" ForeColor="#0066FF" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
<asp:Label ID="LblContieneCompra" runat="server" Text="Y Contiene.:" Font-Bold="True" CssClass="LblContieneCompra"></asp:Label>
<asp:TextBox ID="TxtContieneCompra" runat="server" CssClass="TxtContieneCompra" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="50" Text="0.00" Width="100px" AutoPostBack="True" onKeyPress="return acceptNum(event)" OnTextChanged="TxtContieneCompra_TextChanged"></asp:TextBox>
<asp:Label ID="LblUnidCompra" runat="server" Text="Unid (s)" CssClass="LblUnidCompra"></asp:Label>
</asp:Panel>

<asp:Label ID="LblClasificacionLetrero" runat="server" Text="Clasificacion Producto" Font-Bold="True" CssClass="LblClasificacionLetrero" ForeColor="Fuchsia"></asp:Label>

<asp:Panel ID="PnlOtros" runat="server" CssClass="PnlOtros" Width="448px" Height="100px" BorderStyle="Ridge">
<asp:Label ID="LblCantidadMinima" runat="server" Text="Cantidad Minima.:" Font-Bold="True" CssClass="LblPrecioCompra"></asp:Label>
<asp:TextBox ID="TxtCantidadMinima" runat="server" CssClass="TxtCantidadMinima" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="50" Text="0.00" Width="100px" AutoPostBack="True" onKeyPress="return acceptNum(event)" OnTextChanged="TxtCantidadMinima_TextChanged"></asp:TextBox>
<asp:Label ID="LblFechaCompra" runat="server" Text="Fecha Compra.:" Font-Bold="True" CssClass="LblFechaCompra"></asp:Label>
<asp:TextBox ID="TxtFechaCompra" runat="server" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="15px" maxlength="25" CssClass="TxtFechaCompra" Width="103px" ReadOnly="True"></asp:TextBox>
<asp:ImageButton ID="ImbCalendarioCompra" runat="server" ImageUrl="~/Imagenes/Calendario4.png" CssClass="ImbCalendarioCompra" Height="21px" OnClick="ImbCalendarioCompra_Click" />
<asp:Panel ID="PnlFecheroCompra" runat="server" BorderStyle="Solid" Width="17.2%" Height="22%" BorderWidth="0px" CssClass="PnlCalendario" Visible="False">
<asp:Calendar ID="CldCalendarioCompra" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="70%" ForeColor="#663399" Height="100%" ShowGridLines="True" Width="100%" OnSelectionChanged="CldCalendarioCompra_SelectionChanged">
<DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1%" />
<NextPrevStyle Font-Size="110%" ForeColor="#FFFFCC" />
<OtherMonthDayStyle ForeColor="#CC9966" />
<SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
<SelectorStyle BackColor="#FFCC66" />
<TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="110%" ForeColor="#FFFFCC" />
<TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
</asp:Calendar>
</asp:Panel>
<asp:Label ID="LblFechaExpiracion" runat="server" Text="Fecha Expiracion.:" Font-Bold="True" CssClass="LblFechaExperiracion"></asp:Label>
<asp:TextBox ID="TxtFechaExpiracion" runat="server" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="25" CssClass="TxtFechaExperiracion" Width="103px" ReadOnly="True"></asp:TextBox>
<asp:ImageButton ID="ImbCalendarioExpiracion" runat="server" ImageUrl="~/Imagenes/Calendario4.png" CssClass="ImbCalendarioExpiracion" Height="21px" OnClick="ImbCalendarioExpiracion_Click" />
<asp:Label ID="LblSuplidor" runat="server" Text="Suplidor.:" Font-Bold="True" CssClass="LblSuplidor"></asp:Label>
<asp:DropDownList ID="DdlSuplidor" runat="server" Width="171px" CssClass="TxtSuplidor" ForeColor="#0066FF" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
<asp:Label ID="LblMarca" runat="server" Text="Marca.:" Font-Bold="True" CssClass="LblMarca"></asp:Label>
<asp:DropDownList ID="DdlMarca" runat="server" Width="130px" CssClass="DdlMarca" ForeColor="#0066FF" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
<asp:Label ID="LblModelo" runat="server" Text="Modelo.:" Font-Bold="True" CssClass="LblModelo"></asp:Label>
<asp:DropDownList ID="DdlModelo" runat="server" Width="130px" CssClass="DdlModelo" ForeColor="#0066FF" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
<asp:Label ID="LblSerie" runat="server" Text="Serie.:" Font-Bold="True" CssClass="LblSerie"></asp:Label>
<asp:TextBox ID="TxtSerie" runat="server" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="50" CssClass="TxtSerie" Width="122px"></asp:TextBox>
<asp:Label ID="LblColor" runat="server" Text="Color.:" Font-Bold="True" CssClass="LblColor"></asp:Label>
<asp:DropDownList ID="DdlColor" runat="server" Width="130px" CssClass="DdlColor" ForeColor="#0066FF" Font-Bold="True" Font-Size="Medium"></asp:DropDownList>
</asp:Panel>

<asp:Panel ID="PnlNota" runat="server" CssClass="PnlNota" Width="301px" Height="100px" BorderStyle="Ridge">
<asp:Label ID="LblNota" runat="server" Text="Nota.:" Font-Bold="True" CssClass="LblNota"></asp:Label>
<asp:TextBox ID="TxtNota" runat="server" ForeColor="#0066FF" Font-Bold="True" AutoCompleteType="Disabled" font-size="Medium" maxlength="100" CssClass="TxtNota" Width="217px" TextMode="MultiLine" Height="77px"></asp:TextBox>
</asp:Panel>

<asp:Panel ID="PnlGridview" runat="server" BorderStyle="Outset" Width="760px" CssClass="PnlPanel2" Height="116px" ScrollBars="Auto" ToolTip="Buscar Registro">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Font-Size="15px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
<asp:BoundField DataField="Pro_Codigo" HeaderText="Codigo" />
<asp:BoundField DataField="Pro_Nombre" HeaderText="Nombre Producto" />
<asp:BoundField DataField="Pro_FechaCompra" HeaderText="Fecha Compra" DataFormatString="{0:dd/MM/yyyy}" />
<asp:BoundField DataField="Pro_PrecioCompraRD" HeaderText="Precio Compra RD$" />
<asp:BoundField DataField="Pro_PrecioCompraUS" HeaderText="Precio Compra US$" />
<asp:BoundField DataField="Pro_Bodega" HeaderText="Bodega" ItemStyle-Width="10px" ItemStyle-Wrap="false" />
<asp:BoundField DataField="Pro_Ubicacion" HeaderText="Ubicacion" />
<asp:BoundField DataField="Pro_Status" HeaderText="Status Mercancia" />
<asp:BoundField DataField="Pro_AplicarItebis" HeaderText="Aplicar Itebis" />
<asp:BoundField DataField="Pro_Fisico" HeaderText="Mercancia Fisica" />
<asp:BoundField DataField="Pro_Servicio" HeaderText="Servicios" />
<asp:BoundField DataField="Pro_Ocasional" HeaderText="Mercancia Ocasional" />
<asp:BoundField DataField="Pro_CantidadInicial" HeaderText="Cantidad Inicial" />
<asp:BoundField DataField="Pro_CantidadMinima" HeaderText="Cantidad Minima" />
<asp:BoundField DataField="Pro_FechaExpiracion" HeaderText="Fecha Expiracion" DataFormatString="{0:dd/MM/yyyy}" />
<asp:BoundField DataField="Pro_Suplidor" HeaderText="Suplidor" ItemStyle-Width="10px" ItemStyle-Wrap="false" />
<asp:BoundField DataField="Pro_Marca" HeaderText="Marca" />
<asp:BoundField DataField="Pro_Modelo" HeaderText="Modelo" ItemStyle-Width="10px" ItemStyle-Wrap="false" />
<asp:BoundField DataField="Pro_Serie" HeaderText="Serie" />
<asp:BoundField DataField="Pro_Color" HeaderText="Color" />
<asp:BoundField DataField="Pro_Categoria" HeaderText="Categoria" />
<asp:BoundField DataField="Pro_SubCategoria" HeaderText="SubCategoria" />
<asp:BoundField DataField="Pro_Referencia" HeaderText="Referencia" />
<asp:BoundField DataField="Pro_VendePor" HeaderText=" Se Vende Por" />
<asp:BoundField DataField="Pro_ContieneVende" HeaderText="Contiene Unidades" />
<asp:BoundField DataField="Pro_CompraPor" HeaderText="Se Compra Por" />
<asp:BoundField DataField="Pro_ContieneCompra" HeaderText="Contiene Unidades" />
<asp:BoundField DataField="Pro_Nota" HeaderText="Nota" />
</Columns>
</asp:GridView>
</asp:Panel>

<asp:Panel ID="PnlCuadroGridview" runat="server" BorderStyle="Solid" Width="758px" CssClass="PnlGrilla" Height="112px" ScrollBars="Auto" BorderWidth="1px" BackColor="#999999" ToolTip="Buscar Registros">
</asp:Panel>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:Timer ID="Timer1" runat="server" Interval="4000" Enabled="false" OnTick="Timer1_Tick"></asp:Timer>
</asp:Content>

