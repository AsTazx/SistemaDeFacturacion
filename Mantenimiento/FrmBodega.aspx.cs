using SistemaDeFacturacionCS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaDeFacturacionCS.Mantenimiento
{
    public partial class FrmBodega : System.Web.UI.Page
    {
        //Conexion BD
        SqlConnection SqlCon = new SqlConnection();

        private void ContarRegistro()
        {
            //Verificar Cuenta los registro BD
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCon.Open();
            SqlCommand cmd = new SqlCommand("sp_ContarRegistro_Bodegas", SqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            int maxId = Convert.ToInt32(cmd.ExecuteScalar());
            TxtCodigo.Text = maxId.ToString();
            SqlCon.Close();
        }

        private void Reiniciar()
        {
            ContarRegistro();
            TxtReferencia.Focus();

            ImgAceptar.Enabled = true;
            ImbCancelar.Enabled = true;
            ImbBuscar.Enabled = true;
            ImbNuevo.Enabled = false;
            ImbModificar.Enabled = false;

            TxtDescripcion.Enabled = true;
            TxtReferencia.Enabled = true;

            TxtDescripcion.Text = "";
            TxtReferencia.Text = "";

            GridView1.DataBind();

            ImgBarras.ImageUrl = "~/Imagenes/BarraAzul.png";
            LblMensaje2.Text = "Mensajes.:";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            TxtReferencia.Focus();

            try
            {
                if (!IsPostBack)
                {
                    ContarRegistro();
                }
            }
            catch
            {
            }
        }

        protected void ImgAceptar_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtReferencia.Text) ||
string.IsNullOrWhiteSpace(TxtDescripcion.Text))
            {
                ImgBarras.ImageUrl = "~/Imagenes/BarraRoja.png";
                LblMensaje2.Text = "Error: debe completar todos los campos";
                Timer1.Enabled = true;
            }
            else
            {
                //Verificar si existe registro BD
                SqlCon = ConexionDB.getInstancia().CrearConexion();
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("sp_RegistroExiste_Bodega", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Bod_Referencia", TxtReferencia.Text);
                cmd.Parameters.AddWithValue("@Bod_Descripcion", TxtDescripcion.Text);
                cmd.Connection = SqlCon;
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    ImgBarras.ImageUrl = "~/Imagenes/BarraRoja.png";
                    LblMensaje2.Text = "Mensaje.: Registro Existe";
                    Timer1.Enabled = true;
                }
                else
                {
                    // Insertar registro en BD
                    SqlCon = ConexionDB.getInstancia().CrearConexion();
                    SqlCon.Open();
                    SqlCommand cmd2 = new SqlCommand("sp_Insert_Bodega", SqlCon);
                    cmd2.CommandType = CommandType.StoredProcedure;

                    cmd2.Parameters.AddWithValue("@Bod_Codigo", TxtCodigo.Text);
                    cmd2.Parameters.AddWithValue("@Bod_Referencia", TxtReferencia.Text);
                    cmd2.Parameters.AddWithValue("@Bod_Descripcion", TxtDescripcion.Text);
                    cmd2.ExecuteScalar();

                    ImgBarras.ImageUrl = "~/Imagenes/BarraVerde.png";
                    LblMensaje2.Text = "Mensaje.: Registro guardado satisfactoriamente";

                    ImgAceptar.Enabled = false;
                    ImbCancelar.Enabled = false;
                    ImbBuscar.Enabled = false;
                    ImbNuevo.Enabled = true;

                    TxtDescripcion.Enabled = false;
                    TxtReferencia.Enabled = false;

                    SqlCon.Close();
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ImgBarras.ImageUrl = "~/Imagenes/BarraAzul.png";
            LblMensaje2.Text = "Mensajes";
            Timer1.Enabled = false;
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
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            DataTable dt = new DataTable();
            SqlCommand comando = new SqlCommand("sp_Consulta_GridBodega", SqlCon);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(comando);
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SqlCon.Close();

            ImgAceptar.Enabled = false;
            ImbModificar.Enabled = true;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtCodigo.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;
            TxtReferencia.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[2].Text;
            TxtDescripcion.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[3].Text;
        }

        protected void ImbModificar_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtReferencia.Text) ||
string.IsNullOrWhiteSpace(TxtDescripcion.Text))
            {
                ImgBarras.ImageUrl = "~/Imagenes/BarraRoja.png";
                LblMensaje2.Text = "Mensaje.: Existen campos en blanco, no se puede modificar este registro";
                Timer1.Enabled = true;
            }
            else
            {
                //Verificar si existe registro BD
                SqlCon = ConexionDB.getInstancia().CrearConexion();
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("sp_RegistroExiste_Bodega", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Bod_Referencia", TxtReferencia.Text);
                cmd.Parameters.AddWithValue("@Bod_Descripcion", TxtDescripcion.Text);
                cmd.Connection = SqlCon;
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    ImgBarras.ImageUrl = "~/Imagenes/BarraRoja.png";
                    LblMensaje2.Text = "Mensaje.: Registro Existe";
                    Timer1.Enabled = true;
                }
                else
                {
                    rd.Close();

                    SqlCommand comando1 = new SqlCommand("sp_Update_Bodega", SqlCon);
                    comando1.CommandType = CommandType.StoredProcedure;

                    comando1.Parameters.AddWithValue("@Bod_Codigo", TxtCodigo.Text);
                    comando1.Parameters.AddWithValue("@Bod_Referencia", TxtReferencia.Text);
                    comando1.Parameters.AddWithValue("@Bod_Descripcion", TxtDescripcion.Text);
                    comando1.ExecuteNonQuery();
                    SqlCon.Close();

                    ImgBarras.ImageUrl = "~/Imagenes/BarraVerde.png";
                    LblMensaje2.Text = "Registro modificado exitosamente";
                    Timer1.Enabled = true;

                    ImbModificar.Enabled = false;
                }
            }
        }
    }
}