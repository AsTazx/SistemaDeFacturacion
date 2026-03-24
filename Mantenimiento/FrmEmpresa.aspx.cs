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
    public partial class FrmEmpresa : System.Web.UI.Page
    {
        //Conexion BD
        SqlConnection SqlCon = new SqlConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ImgBarras.ImageUrl = "~/Imagenes/BarraAzul.png";
            LblMensaje2.Text = "Mensajes";
            Timer1.Enabled = false;
        }

        protected void ImgAceptar_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombre.Text) ||
string.IsNullOrWhiteSpace(TxtDireccion.Text) ||
string.IsNullOrWhiteSpace(TxtTelefono.Value) || string.IsNullOrWhiteSpace(TxtRNC.Value))
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
                SqlCommand cmd = new SqlCommand("sp_ContarRegistro_Emoresa", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                int output = (int)cmd.ExecuteScalar();

                if (output >= 1)
                {
                    ImgBarras.ImageUrl = "~/Imagenes/BarraMarron.png";
                    LblMensaje2.Text = "Advertencia: La empresa esta creada, no se puede crear dos empresas en el sistema";
                    Timer1.Enabled = true;
                }
                else
                {
                    try
                    {
                        int tamanio = fuploadImagen.PostedFile.ContentLength;
                        byte[] ImagenOriginal = new byte[tamanio];

                        fuploadImagen.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
                        Bitmap ImagenOriginalBinaria = new Bitmap(fuploadImagen.PostedFile.InputStream);
                        string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);

                        imgPreview.ImageUrl = ImagenDataURL64;

                        SqlCommand cmd2 = new SqlCommand("sp_Insert_Empresa", SqlCon);
                        cmd2.CommandType = CommandType.StoredProcedure;

                        cmd2.Parameters.AddWithValue("@Emp_Nombre", TxtNombre.Text);
                        cmd2.Parameters.AddWithValue("@Emp_Direccion", TxtDireccion.Text);
                        cmd2.Parameters.AddWithValue("@Emp_Telefono", TxtTelefono.Value);
                        cmd2.Parameters.AddWithValue("@Emp_RNC", TxtRNC.Value);
                        cmd2.Parameters.AddWithValue("@Emp_Logo", SqlDbType.Image).Value = ImagenOriginal;

                        cmd2.ExecuteScalar();

                        ImgBarras.ImageUrl = "~/Imagenes/BarraVerde.png";
                        LblMensaje2.Text = "Registro guardado satisfactoriamente";

                        SqlCon.Close();
                    }
                    catch
                    {
                        ImgBarras.ImageUrl = "~/Imagenes/BarraRoja.png";
                        LblMensaje2.Text = "Error debes cargar primero la imagen";
                        Timer1.Enabled = true;
                    }
                }
            }
        }

        protected void ImbCancelar_Click(object sender, ImageClickEventArgs e)
        {
            fuploadImagen.Attributes.Clear();
            TxtNombre.Text = "";
            TxtDireccion.Text = "";
            TxtTelefono.Value = "";
            TxtRNC.Value = "";
        }
    }
}