<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs" Inherits="SistemaDeFacturacionCS.Login.FrmLogin" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema de Facturacion</title>
    <link rel="shortcut icon" type="image/x-icon" href="/Imagenes/Favicon.png" />
    <style type="text/css">
        body {
            background-image: url('/Imagenes/FondoLogin.jpg');
        }
        .auto-style1 {
            position: absolute;
            top: 73px;
            left: 250px;
            width: 253px;
            height: 30px;
        }
        .auto-style2 {
            position: absolute;
            top: 133px;
            left: 250px;
            width: 254px;
            height: 30px;
        }
        .auto-style3 {
            position: absolute;
            top: 95px;
            left: 14px;
        }
        .auto-style5 {
            position: absolute;
            top: 199px;
            left: 400px;
            width: 400px;
            height: 30px;
            font-size: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="ImgCajasAlmacen" runat="server" ImageUrl="~/Imagenes/CajasAlmacen.png" CssClass="auto-style5" Height="430px" Width="790px" />
            
            <div id="Logo">
                <h1>SISTEMA</h1>
                <h3>DE FACTURACION ELECTRONICA</h3>
            </div>
           
            <asp:Panel ID="PnlAcceso" runat="server" BorderColor="Black" BorderStyle="Solid" CssClass="PnlAcceso" Width="520px" Height="268px" BackImageUrl="~/Imagenes/FondoLogin.png">
            <asp:Panel ID="PnlControl" runat="server" Height="37px" BackColor="#3399FF" Width="520px">
             
            </asp:Panel>

 <%--DATOS DEL USUARIO --%>
<asp:Image ID="ImgCerradura" runat="server" ImageUrl="~/Imagenes/CerraduraRoja.png" Height="85px" Width="95px" CssClass="auto-style3" />
<asp:Label ID="LblUsuario" runat="server" Text="Usuario.:" Font-Bold="True" ForeColor="White" Font-Size="Large" CssClass="LblUsuario"></asp:Label>
<asp:Label ID="LblClave" runat="server" Text="Clave.:" Font-Bold="True" ForeColor="White" Font-Size="Large" CssClass="LblClave"></asp:Label>
<asp:TextBox ID="TxtUsuario" runat="server" Font-Bold="True" ToolTip="Introduzca su Usuario" Font-Size="Large" ForeColor="#0066FF" AutoCompleteType="Disabled" CssClass="auto-style1"></asp:TextBox>
<asp:TextBox ID="TxtClave" runat="server" Font-Bold="True" ToolTip="Introduzca su Usuario" Font-Size="Large" ForeColor="#0066FF" AutoCompleteType="Disabled" CssClass="auto-style2" TextMode="Password"></asp:TextBox>
<asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" Font-Bold="True" ToolTip="Presione para Aceptar la validacion" BorderStyle="Outset" Width="80px" Height="40px" CssClass="BtnAceptar" OnClick="BtnAceptar_Click" />

<%--PANEL DEL MENSAJE--%>
<asp:Panel ID="PnlMensaje" runat="server" Height="37px" Width="520px" CssClass="PnlMensaje" BackColor="Black">
<asp:Label ID="LblMensaje" runat="server" Text="Mensaje.:" Font-Bold="True" ForeColor="White" CssClass="LblMensaje"></asp:Label>
</asp:Panel>
</asp:Panel>


            <%--FUNCIONALIDAD DEL TIMER--%>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:Timer ID="Timer1" runat="server" Interval="5000" Enabled="False" OnTick="Timer1_Tick1"></asp:Timer>
        </div>
    </form>
</body>
</html>