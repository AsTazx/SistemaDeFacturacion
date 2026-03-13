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



namespace SistemaDeFacturacionCS.Login
{
    public partial class Principal : System.Web.UI.MasterPage
    {

        //Conexion BD
        SqlConnection SqlCon = new SqlConnection();

        protected void ConsultarImagenes()
        {

            //Llamar imagen de la base de datos
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCommand cmd = new SqlCommand("sp_ConsultarImagen_Emoresa", SqlCon);
            DataTable ImagenesDB = new DataTable();
            Repeater1.DataSource = ImagenesDB;
            Repeater1.DataBind();
            SqlCon.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            LblIdentificacion.Text = (string)Session["Log_Nombre"] + (" ") + (string)Session["Log_Apellido"];

            ConsultarImagenes();

        }
    }
}