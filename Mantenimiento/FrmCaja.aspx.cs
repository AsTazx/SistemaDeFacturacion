using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace SistemaDeFacturacionCS.Mantenimiento
{
    public partial class FrmCaja : System.Web.UI.Page
    {
        //CONEXION DB
        SqlConnection SqlCon = new SqlConnection();

        private void ContarRegistro()
        {
            //VERIFICAR SI EXISTE REGISTRO BD
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCon.Open();
            SqlCommand cmd = new SqlCommand("Sp_ContarRegistro_Caja", SqlCon);
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
            catch { }
        }

        protected void ImgAceptar_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtReferencia.Text) || string.IsNullOrWhiteSpace(TxtDescripcion.Text))
            {
                ImgBarras.ImageUrl = "~/Imagenes/BarraRoja.png";
                LblMensaje2.Text = "Error: debe completar todos los campos";
                Timer1.Enabled = true;
            }
            else
            {
                SqlCon = ConexionDB.getInstancia().CrearConexion();
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("sp_RegistroExiste_Caja", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Caj_Referencia", TxtReferencia.Text);
                cmd.Parameters.AddWithValue("@Caj_Descripcion", TxtDescripcion.Text);
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
                    SqlCommand cmd2 = new SqlCommand("sp_Insert_Caja", SqlCon);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@Caj_Codigo", TxtCodigo.Text);
                    cmd2.Parameters.AddWithValue("@Caj_Referencia", TxtReferencia.Text);
                    cmd2.Parameters.AddWithValue("@Caj_Descripcion", TxtDescripcion.Text);
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
            SqlCommand comando = new SqlCommand("sp_Consulta_GridCaja", SqlCon);
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
                SqlCon = ConexionDB.getInstancia().CrearConexion();
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("sp_RegistroExiste_Caja", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Caj_Referencia", TxtReferencia.Text);
                cmd.Parameters.AddWithValue("@Caj_Descripcion", TxtDescripcion.Text);
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

                    SqlCommand comando1 = new SqlCommand("sp_Update_Caja", SqlCon);
                    comando1.CommandType = CommandType.StoredProcedure;
                    comando1.Parameters.AddWithValue("@Caj_Codigo", TxtCodigo.Text);
                    comando1.Parameters.AddWithValue("@Caj_Referencia", TxtReferencia.Text);
                    comando1.Parameters.AddWithValue("@Caj_Descripcion", TxtDescripcion.Text);
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