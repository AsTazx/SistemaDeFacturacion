<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/MPMantenimiento.master" AutoEventWireup="true" CodeBehind="FrmEmpresa.aspx.cs" Inherits="SistemaDeFacturacionCS.Mantenimiento.FrmEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">

<h2>&nbsp Datos empresa</h2>

     <script language="JavaScript">
     <!--
         var nav4 = window.Event ? true : false;
         function acceptNum(evt) {
             // NOTE: BACKSPACE = 8, ENTER = 13, '0' = 48, '9' = 57, '.' - 46
             var key = nav4 ? evt.which : evt.keyCode;
             return (key <= 13 || (key >= 48 && key <= 57) || key == 46);
         }

         //-->
     </script>

    <asp:Panel ID="PnlBotonera" runat="server" BorderStyle="Solid" Width="138px" Height="639px" CssClass="PnlBotonera" BackImageUrl="~/Imagenes/Negra.png">
        <asp:ImageButton ID="ImgAceptar" runat="server" ImageUrl="~/Imagenes/Aceptar.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImgAceptar" Enabled="true"    />
        <asp:ImageButton ID="ImbNuevo" runat="server" ImageUrl="~/Imagenes/Nuevo.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbNuevo" Enabled="False"    />
        <asp:ImageButton ID="ImbCancelar" runat="server" ImageUrl="~/Imagenes/Cancelar.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbCancelar"    />
        <asp:ImageButton ID="ImbBuscar" runat="server" ImageUrl="~/Imagenes/Buscar.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbBuscar" Enabled="False"    />
        <asp:ImageButton ID="ImbModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbModificar" Enabled="False"    />
        <asp:ImageButton ID="ImbImprimir" runat="server" ImageUrl="~/Imagenes/Printer.png" BorderColor="#999999" BorderStyle="Solid" CssClass="ImbPrinter" Enabled="False"    />
    </asp:Panel>

    <asp:Panel ID="Panel1" runat="server" CssClass="ImgBarraAzul" Width="784px" Height="50px">
        <asp:Image ID="ImgBarras" runat="server" ImageUrl="~/Imagenes/BarraAzul.png" CssClass="ImgBarraAzul" Width="852px" Height="50px" />
        <asp:Label ID="LblMensaje2" runat="server" Text="Mensaje:" Font-Bold="true" ForeColor="Black" CssClass="LblMensaje2"></asp:Label>
    </asp:Panel>

    <asp:Panel ID="PnlDatos" runat="server" BorderStyle="Solid" BorderColor="Black" Width="775px" Height="507px" CssClass="PnlDatos" BackImageUrl="~/Imagenes/Crema.png">

<div class="container">
    <div class="row">
      <div class="col-md-4 col-md-offset-4">
          <asp:FileUpload ID="fuploadImagen" accept=".jpg, .png" runat="server" CssClass="form-control" Font-Bold="true"/>
          <br />
          <br />
          <asp:Image ID="imgPreview" runat="server" Width="200px" Height="150px" ImageUrl=" " BorderColor="Black" BorderStyle="Solid" CssClass="img-1" />
          <br />
          <br />
      </div>
    </div>
</div>

        <asp:Label ID="LblNombre" runat="server" Text="Nombre :" Font-Bold="True" CssClass="LblNombre"></asp:Label>
        <asp:Label ID="LblDireccion" runat="server" Text="Direccion :" Font-Bold="true" CssClass="LblDireccion"></asp:Label>
        <asp:Label ID="LblTelefono" runat="server" Text="Telefono :" Font-Bold="true" CssClass="Telefono"></asp:Label>
        <asp:Label ID="LblRNC" runat="server" Text="Rnc :" Font-Bold="true" CssClass="RNC"></asp:Label>

        <asp:TextBox ID="TxtNombre" runat="server" CssClass="TxtNombre" ForeColor="#0066FF" AutoCompleteType="Disabled" Font-Size="Medium" Font-Bold="true" MaxLength="50"></asp:TextBox>
        <asp:TextBox ID="TxtDireccion" runat="server" CssClass="TxtDireccion" ForeColor="#0066FF" AutoCompleteType="Disabled" Font-Size="Medium" Font-Bold="true" MaxLength="50"></asp:TextBox>

<div class="TxtRNC" >
 <input id="TxtRNC" runat="server" style="width: 97%; height: 2.4%; font-weight: bold; font-size: medium; color:#0066FF" title="Introduzca el RNC de la compania" onfocus ="this . style . borderColor='black'" onblur =" this . style . borderColor= '' " onKeyPress="return acceptNum(event)" type="text" name="RNC" placeholder="" onkeyup=" var RNC = this.value; if (RNC.match(/^\d{3}\-\d{5}$/) !== null) { this.value = RNC + '-';}" maxlength="11" autocomplete="off" />

</div>
    </asp:Panel>


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="4000" OnTick="Timer1_Tick"></asp:Timer>
     </asp:Content>
