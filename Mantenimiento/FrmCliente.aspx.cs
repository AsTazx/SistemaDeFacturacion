using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaDeFacturacionCS.Mantenimiento
{
    public partial class FrmCliente : System.Web.UI.Page
    {
        //Conexion BD
        SqlConnection SqlCon = new SqlConnection();

        private void ContarRegistro()
        {
            //Verificar si existe registro BD
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCon.Open();
            SqlCommand cmd = new SqlCommand("sp_ContarRegistro_Clientes", SqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            int maxId = Convert.ToInt32(cmd.ExecuteScalar());
            TxtCodigo.Text = maxId.ToString();
            SqlCon.Close();
        }

        private DataSet GetData(string SPName, SqlParameter SPParameter)
        {
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCon.Open();
            SqlDataAdapter da = new SqlDataAdapter(SPName, SqlCon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (SPParameter != null)
            {
                da.SelectCommand.Parameters.Add(SPParameter);
            }

            DataSet DS = new DataSet();
            da.Fill(DS);

            return DS;
        }

        private void CambioCliente()
        {
            if (DdlTipo.Text == "Personal")
            {
                PnlEmpresarial.Visible = false;
                PnlPersonal.Visible = true;
            }
            else
            {
                PnlPersonal.Visible = false;
                PnlEmpresarial.Visible = true;
            }
        }

        public void Desactivar_Botones()
        {
            ImgAceptar.Enabled = false;
            ImbCancelar.Enabled = false;
            ImbModificar.Enabled = false;
            ImbBuscar.Enabled = false;
            ImbImprimir.Enabled = false;

            DdlTipo.Enabled = false;
            TxtNombre.Enabled = false;
            TxtRNCCliente.Disabled = true;
            TxtContacto.Enabled = false;
            TxtCargo.Enabled = false;
            TxtPagina.Enabled = false;
            TxtApellido.Enabled = false;
            TxtCedulaCliente.Disabled = true;
            TxtDireccion.Enabled = false;
            DdlPais.Enabled = false;
            DdlProvincia.Enabled = false;
            TxtTelefono.Disabled = true;
            TxtCelular.Disabled = true;
            TxtCorreo.Enabled = false;
        }

        private void Reiniciar()
        {
            ContarRegistro();

            ImgAceptar.Enabled = true;
            ImbNuevo.Enabled = false;
            ImbCancelar.Enabled = true;
            ImbModificar.Enabled = false;
            ImbBuscar.Enabled = true;
            ImbImprimir.Enabled = false;

            DdlTipo.Enabled = true;
            TxtNombre.Enabled = true;
            TxtRNCCliente.Disabled = false;
            TxtContacto.Enabled = true;
            TxtCargo.Enabled = true;
            TxtPagina.Enabled = true;
            TxtApellido.Enabled = true;
            TxtCedulaCliente.Disabled = false;
            TxtDireccion.Enabled = true;
            DdlPais.Enabled = true;
            DdlProvincia.Enabled = true;
            TxtTelefono.Disabled = false;
            TxtCelular.Disabled = false;
            TxtCorreo.Enabled = true;

            llenadoTipoCliente();
            TxtNombre.Text = "";
            TxtRNCCliente.Value = "";
            TxtContacto.Text = "";
            TxtCargo.Text = "";
            TxtPagina.Text = "";
            TxtApellido.Text = "";
            TxtCedulaCliente.Value = "";
            TxtDireccion.Text = "";

            DdlPais.SelectedIndex = 0;
            DdlProvincia.SelectedIndex = 0;
            DdlProvincia.Enabled = false;
            DdlPais.SelectedItem.Text = "Selecciona Pais";
            DdlProvincia.SelectedItem.Text = "Selecciona Provincia";

            TxtTelefono.Value = "";
            TxtCelular.Value = "";
            TxtCorreo.Text = "";

            PnlPersonal.Visible = false;
            PnlEmpresarial.Visible = true;

            GridView1.DataBind();

            ImgBarras.ImageUrl = "~/Imagenes/BarraAzul.png";
            LblMensaje2.Text = "Mensajes.:";
        }

        private void llenadoTipoCliente()
        {
            //LLenado Tipo de suplidor
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCon.Open();
            SqlCommand comando = new SqlCommand("sp_Consulta_DdlCliente", SqlCon);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DdlTipo.DataTextField = ds.Tables[0].Columns["Tip_Descripcion"].ToString();
            DdlTipo.DataSource = ds.Tables[0];
            DdlTipo.DataBind();
        }

        private void LlenadoPais()
        {
            DdlPais.DataSource = GetData("Sp_Pais", null);
            DdlPais.DataBind();

            ListItem liPais = new ListItem("Selecciona Pais", "-1");
            DdlPais.Items.Insert(0, liPais);

            ListItem liProvincia = new ListItem("Selecciona Provincia", "-1");
            DdlProvincia.Items.Insert(0, liProvincia);

            DdlProvincia.Enabled = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ContarRegistro();
                    llenadoTipoCliente();
                    LlenadoPais();
                }
                CambioCliente();
            }
            catch
            {
            }
        }

        protected void DdlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlPais.SelectedIndex == 0)
            {
                DdlProvincia.SelectedIndex = 0;
                DdlProvincia.Enabled = false;
            }
            else
            {
                DdlProvincia.Enabled = true;
                SqlParameter parameter = new SqlParameter("@Id_Provincia", DdlPais.SelectedValue);
                DataSet DS = GetData("Sp_Provincia", parameter);

                DdlProvincia.DataSource = DS;
                DdlProvincia.DataBind();

                ListItem liProvincia = new ListItem("Selecciona Provincia", "-1");
                DdlProvincia.Items.Insert(0, liProvincia);

                TextBox1.Visible = false;
                TextBox2.Visible = false;
            }
        }

        protected void ImgAceptar_Click(object sender, ImageClickEventArgs e)
        {
            if (DdlTipo.Text == "Empresarial")
            {
                if (string.IsNullOrWhiteSpace(TxtNombre.Text) ||
                    string.IsNullOrWhiteSpace(TxtRNCCliente.Value) ||
                    string.IsNullOrWhiteSpace(TxtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(DdlPais.Text) ||
                    string.IsNullOrWhiteSpace(DdlProvincia.Text) ||
                    string.IsNullOrWhiteSpace(TxtTelefono.Value))
                {
                    ImgBarras.ImageUrl = "~/Imagenes/BarraRoja.png";
                    LblMensaje2.Text = "Los campos Nombre, RNC, Direccion, Pais, Provincia y Telefono no pueden quedar en blanco";
                    ImbNuevo.Enabled = false;
                    Timer1.Enabled = true;
                }
                else
                {
                    SqlCon = ConexionDB.getInstancia().CrearConexion();
                    SqlCon.Open();
                    SqlCommand cmd2 = new SqlCommand("sp_RegistroExiste_Cliente", SqlCon);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@Cli_RNC", TxtRNCCliente.Value);
                    cmd2.Connection = SqlCon;
                    SqlDataReader rd = cmd2.ExecuteReader();

                    if (rd.HasRows)
                    {
                        ImgBarras.ImageUrl = "~/Imagenes/BarraRoja.png";
                        LblMensaje2.Text = "Registro Existe";
                        Timer1.Enabled = true;
                    }
                    else
                    {
                        SqlCon = ConexionDB.getInstancia().CrearConexion();
                        SqlCon.Open();

                        try
                        {
                            SqlCommand cmd = new SqlCommand("sp_Insert_Cliente", SqlCon);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Cli_Codigo", TxtCodigo.Text);
                            cmd.Parameters.AddWithValue("@Cli_Tipo", DdlTipo.Text);
                            cmd.Parameters.AddWithValue("@Cli_Nombre", TxtNombre.Text);
                            cmd.Parameters.AddWithValue("@Cli_RNC", TxtRNCCliente.Value);
                            cmd.Parameters.AddWithValue("@Cli_Contacto", TxtContacto.Text);
                            cmd.Parameters.AddWithValue("@Cli_Cargo", TxtCargo.Text);
                            cmd.Parameters.AddWithValue("@Cli_Pagina", TxtPagina.Text);
                            cmd.Parameters.AddWithValue("@Cli_Direccion", TxtDireccion.Text);
                            cmd.Parameters.AddWithValue("@Cli_Telefono", TxtTelefono.Value);
                            cmd.Parameters.AddWithValue("@Cli_Celular", TxtCelular.Value);
                            cmd.Parameters.AddWithValue("@Cli_Correo", TxtCorreo.Text);
                            cmd.Parameters.AddWithValue("@Cli_Pais", DdlPais.Text);
                            cmd.Parameters.AddWithValue("@Cli_Provincia", DdlProvincia.Text);
                            cmd.ExecuteScalar();

                            ImgBarras.ImageUrl = "~/Imagenes/BarraVerde.png";
                            LblMensaje2.Text = "Registro guardado satisfactoriamente";

                            Desactivar_Botones();
                            ImbNuevo.Enabled = true;
                            SqlCon.Close();
                        }
                        catch
                        {
                            ImgBarras.ImageUrl = "~/Imagenes/BarraRoja.png";
                            LblMensaje2.Text = "Registro Existe";
                            Timer1.Enabled = true;
                        }
                    }
                }
            }

            if (DdlTipo.Text == "Personal")
            {
                if (string.IsNullOrWhiteSpace(TxtNombre.Text) ||
                    string.IsNullOrWhiteSpace(TxtApellido.Text) ||
                    string.IsNullOrWhiteSpace(TxtCedulaCliente.Value) ||
                    string.IsNullOrWhiteSpace(TxtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(DdlPais.Text) ||
                    string.IsNullOrWhiteSpace(DdlProvincia.Text) ||
                    string.IsNullOrWhiteSpace(TxtCelular.Value))
                {
                    ImgBarras.ImageUrl = "~/Imagenes/BarraRoja.png";
                    LblMensaje2.Text = "Los campos Nombre, Apellido, Cedula, Direccion, Pais, Provincia y Celular no pueden quedar en blanco";
                    ImbNuevo.Enabled = false;
                    Timer1.Enabled = true;
                }
                else
                {
                    SqlCon = ConexionDB.getInstancia().CrearConexion();
                    SqlCon.Open();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("sp_Insert_Cliente", SqlCon);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Cli_Codigo", TxtCodigo.Text);
                        cmd.Parameters.AddWithValue("@Cli_Tipo", DdlTipo.Text);
                        cmd.Parameters.AddWithValue("@Cli_Nombre", TxtNombre.Text);
                        cmd.Parameters.AddWithValue("@Cli_RNC", TxtRNCCliente.Value);
                        cmd.Parameters.AddWithValue("@Cli_Contacto", TxtContacto.Text);
                        cmd.Parameters.AddWithValue("@Cli_Cargo", TxtCargo.Text);
                        cmd.Parameters.AddWithValue("@Cli_Pagina", TxtPagina.Text);
                        cmd.Parameters.AddWithValue("@Cli_Apellido", TxtApellido.Text);
                        cmd.Parameters.AddWithValue("@Cli_Cedula", TxtCedulaCliente.Value);
                        cmd.Parameters.AddWithValue("@Cli_Direccion", TxtDireccion.Text);
                        cmd.Parameters.AddWithValue("@Cli_Telefono", TxtTelefono.Value);
                        cmd.Parameters.AddWithValue("@Cli_Celular", TxtCelular.Value);
                        cmd.Parameters.AddWithValue("@Cli_Correo", TxtCorreo.Text);
                        cmd.Parameters.AddWithValue("@Cli_Pais", DdlPais.Text);
                        cmd.Parameters.AddWithValue("@Cli_Provincia", DdlProvincia.Text);
                        cmd.ExecuteScalar();

                        ImgBarras.ImageUrl = "~/Imagenes/BarraVerde.png";
                        LblMensaje2.Text = "Registro guardado satisfactoriamente";

                        Desactivar_Botones();
                        ImbNuevo.Enabled = true;
                        SqlCon.Close();
                    }
                    catch
                    {
                        ImgBarras.ImageUrl = "~/Imagenes/BarraRoja.png";
                        LblMensaje2.Text = "Registro Existe";
                        Timer1.Enabled = true;
                    }
                }
            }
        }

        protected void ImbNuevo_Click(object sender, ImageClickEventArgs e)
        {
            Reiniciar();
        }

        protected void ImbCancelar_Click(object sender, ImageClickEventArgs e)
        {
            Reiniciar();
        }

        protected void ImbBuscar_Click(object sender, ImageClickEventArgs e)
        {
        }

        protected void ImbModificar_Click(object sender, ImageClickEventArgs e)
        {
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ImgBarras.ImageUrl = "~/Imagenes/BarraAzul.png";
            LblMensaje2.Text = "Mensajes.:";
            Timer1.Enabled = false;
        }
    }
}