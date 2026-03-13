using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;



namespace SistemaDeFacturacionCS.Login
{
    public partial class FrmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Iniciar el foco en el primer textbox
            TxtUsuario.Focus();
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            //Conexion a la DB
            SqlConnection SqlCon = new SqlConnection();


            //Inserccion de los datos a la DB
            try
            {

                SqlCon = ConexionDB.getInstancia().CrearConexion();
                SqlParameter param = new SqlParameter("@usuario", TxtUsuario.Text.Trim());
                SqlParameter param1 = new SqlParameter("@clave", TxtClave.Text.Trim());
                SqlCommand cmd = new SqlCommand("sp_CheclLogin", SqlCon);
                cmd.Parameters.Add(param);
                cmd.Parameters.Add(param1);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    //variables de seccion
                    Session["Log_Status"] = dr["Log_Status"].ToString();
                    Session["Log_Nombre"] = dr["Log_Nombre"].ToString();
                    Session["Log_Apellido"] = dr["Log_Apellido"].ToString();

                    if (dr["Log_Status"].ToString() == "Activo")
                    {
                        LblMensaje.Text = "Mensaje.: Login correcto";
                        TxtUsuario.Enabled = false;
                        TxtClave.Enabled = false;
                        BtnAceptar.Enabled = false;
                        ImgCerradura.ImageUrl = "~/Imagenes/CerraduraVerde.png";
                        Timer1.Enabled = true;
                    }
                    else
                    {
                        LblMensaje.Text = "Mensaje.: Usuario Inhabilitado";
                        Timer1.Enabled = true;
                    }
                }
                else
                {
                    LblMensaje.Text = "Mensaje.: Login incorrecto";
                    Timer1.Enabled = true;
                }
            }
            catch
            {
                LblMensaje.Text = "Mensaje.: No hay conexion a la Base de Datos";
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
}
      
                protected void Timer1_Tick1(object sender, EventArgs e)
                { 
            //Acceder al menu de la aplicacion y quitar mensajes
            if (LblMensaje.Text == "Mensaje.: Login correcto")
            {
                Session["Log_Usuario"] = LblMensaje.Text;
                Response.Redirect("~/Login/Default.aspx");
            }
            else
            {
                LblMensaje.Text = "Mensaje.:";
            }

            Timer1.Enabled = false;
        }
    }
}