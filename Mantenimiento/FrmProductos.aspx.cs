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
using System.IO;
using System.Windows.Forms;

namespace SistemaDeFacturacionCS.Mantenimiento
{
    public partial class FrmProductos : System.Web.UI.Page
    {
        //Conexion BD
        SqlConnection SqlCon = new SqlConnection();

        private void Reiniciar()
        {
            TxtCodigo.Focus();

            ImgAceptar.Enabled = true;
            ImbCancelar.Enabled = true;
            ImbBuscar.Enabled = true;
            ImbNuevo.Enabled = false;
            ImbModificar.Enabled = false;

            TxtCodigo.Enabled = true;
            TxtCodigo.ReadOnly = false;
            TxtNombreProducto.Enabled = true;
            TxtFechaCompra.Enabled = true;
            TxtPrecioCompra.Enabled = true;
            TxtPrecioCompraUS.Enabled = true;
            DdlBodega.Enabled = true;
            DdlUbicacion.Enabled = true;
            ChbStatus.Enabled = true;
            ChbAplicarItebis.Enabled = true;
            RbtFisico.Enabled = true;
            RbtServicio.Enabled = true;
            RbtOcasional.Enabled = true;
            TxtCantidadInicial.Enabled = true;
            TxtCantidadMinima.Enabled = true;
            TxtFechaExpiracion.Enabled = true;
            DdlSuplidor.Enabled = true;
            DdlMarca.Enabled = true;
            DdlModelo.Enabled = true;
            TxtSerie.Enabled = true;
            DdlColor.Enabled = true;
            DdlCategoria.Enabled = true;
            DdlSubCategoria.Enabled = true;
            TxtReferencia.Enabled = true;
            DdlSeVende.Enabled = true;
            TxtContiene.Enabled = true;
            DdlSeCompra.Enabled = true;
            TxtContieneCompra.Enabled = true;
            TxtNota.Enabled = true;

            TxtCodigo.Text = "";
            TxtNombreProducto.Text = "";
            TxtFechaCompra.Text = DateTime.Today.ToString("yyyy-MM-dd");
            TxtPrecioCompra.Text = "0.00";
            TxtPrecioCompraUS.Text = "0.00";
            DdlBodega.SelectedIndex = 0;
            DdlUbicacion.SelectedIndex = 0;
            ChbStatus.Checked = true;
            ChbAplicarItebis.Checked = false;
            RbtFisico.Checked = true;
            RbtServicio.Checked = false;
            RbtOcasional.Checked = false;
            TxtCantidadInicial.Text = "0.00";
            TxtCantidadMinima.Text = "0.00";
            TxtFechaExpiracion.Text = "";
            DdlSuplidor.SelectedIndex = 0;
            DdlMarca.SelectedIndex = 0;
            DdlModelo.SelectedIndex = 0;
            TxtSerie.Text = "";
            DdlColor.SelectedIndex = 0;
            DdlCategoria.SelectedIndex = 0;
            DdlSubCategoria.SelectedIndex = 0;
            TxtReferencia.Text = "";
            DdlSeVende.SelectedIndex = 0;
            TxtContiene.Text = "0.00";
            DdlSeCompra.SelectedIndex = 0;
            TxtContieneCompra.Text = "0.00";
            TxtNota.Text = "";

            GridView1.DataBind();

            ImgBarras.ImageUrl = "~/Imagenes/BarraAzul.png";
            LblMensaje2.Text = "Mensajes.:";
        }

        private void LlenadoBodega()
        {
            //LLenado Bodegas
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCon.Open();
            SqlCommand comando = new SqlCommand("sp_Consulta_DdlBodega", SqlCon);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DdlBodega.DataTextField = ds.Tables[0].Columns["Bod_Descripcion"].ToString();
            DdlBodega.DataSource = ds.Tables[0];
            DdlBodega.DataBind();
            SqlCon.Close();
        }

        private void LlenadoUbicacion()
        {
            //LLenado Ubicacion
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCon.Open();
            SqlCommand comando = new SqlCommand("sp_Consulta_DdlUbicacion", SqlCon);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DdlUbicacion.DataTextField = ds.Tables[0].Columns["Ubi_Descripcion"].ToString();
            DdlUbicacion.DataSource = ds.Tables[0];
            DdlUbicacion.DataBind();
            SqlCon.Close();
        }

        private void LlenadoSuplidor()
        {
            //LLenado Suplidor
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCon.Open();
            SqlCommand comando = new SqlCommand("sp_Consulta_DdlSuplidores", SqlCon);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DdlSuplidor.DataTextField = ds.Tables[0].Columns["Descripcion"].ToString();
            DdlSuplidor.DataSource = ds.Tables[0];
            DdlSuplidor.DataBind();
            SqlCon.Close();
        }

        private void LlenadoMarca()
        {
            //LLenado Marca
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCon.Open();
            SqlCommand comando = new SqlCommand("sp_Consulta_DdlMarca", SqlCon);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DdlMarca.DataTextField = ds.Tables[0].Columns["Mar_Descripcion"].ToString();
            DdlMarca.DataSource = ds.Tables[0];
            DdlMarca.DataBind();
            SqlCon.Close();
        }

        private void LlenadoModelo()
        {
            //LLenado Modelo
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCon.Open();
            SqlCommand comando = new SqlCommand("sp_Consulta_DdlModelo", SqlCon);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DdlModelo.DataTextField = ds.Tables[0].Columns["Mod_Descripcion"].ToString();
            DdlModelo.DataSource = ds.Tables[0];
            DdlModelo.DataBind();
            SqlCon.Close();
        }

        private void LlenadoColor()
        {
            //LLenado Color
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCon.Open();
            SqlCommand comando = new SqlCommand("sp_Consulta_DdlColor", SqlCon);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DdlColor.DataTextField = ds.Tables[0].Columns["Col_Descripcion"].ToString();
            DdlColor.DataSource = ds.Tables[0];
            DdlColor.DataBind();
            SqlCon.Close();
        }

        private void LlenadoCategoria()
        {
            //LLenado Categoria
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCon.Open();
            SqlCommand comando = new SqlCommand("sp_Consulta_DdlCategoria", SqlCon);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DdlCategoria.DataTextField = ds.Tables[0].Columns["Cat_Descripcion"].ToString();
            DdlCategoria.DataSource = ds.Tables[0];
            DdlCategoria.DataBind();
            SqlCon.Close();
        }

        private void LlenadoSubCategoria()
        {
            //LLenado SubCategoria
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCon.Open();
            SqlCommand comando = new SqlCommand("sp_Consulta_DdlSubCategoria", SqlCon);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DdlSubCategoria.DataTextField = ds.Tables[0].Columns["Sub_Descripcion"].ToString();
            DdlSubCategoria.DataSource = ds.Tables[0];
            DdlSubCategoria.DataBind();
            SqlCon.Close();
        }

        private void LlenadoMedidas()
        {
            //LLenado Medidas
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCon.Open();
            SqlCommand comando = new SqlCommand("sp_Consulta_DdlMedidas", SqlCon);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DdlSeVende.DataTextField = ds.Tables[0].Columns["Med_Descripcion"].ToString();
            DdlSeCompra.DataTextField = ds.Tables[0].Columns["Med_Descripcion"].ToString();
            DdlSeVende.DataSource = ds.Tables[0];
            DdlSeCompra.DataSource = ds.Tables[0];
            DdlSeVende.DataBind();
            DdlSeCompra.DataBind();
            SqlCon.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TxtCodigo.Focus();

                    LlenadoBodega();
                    LlenadoUbicacion();
                    LlenadoSuplidor();
                    LlenadoMarca();
                    LlenadoModelo();
                    LlenadoColor();
                    LlenadoCategoria();
                    LlenadoSubCategoria();
                    LlenadoMedidas();

                    TxtFechaCompra.Text = DateTime.Now.ToString("dd-MM-yyyy").ToString();
                }
            }
            catch
            {
            }
        }

        protected void ImgAceptar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtCodigo.Text) || string.IsNullOrWhiteSpace(TxtNombreProducto.Text))
                {
                    ImgBarras.ImageUrl = "~/Imagenes/BarraRoja.png";
                    LblMensaje2.Text = "Error: debe completar los campos: CODIGO y NOMBRE PRODUCTO";
                    Timer1.Enabled = true;
                }
                else
                {
                    //Verificar si existe registro BD
                    SqlCon = ConexionDB.getInstancia().CrearConexion();
                    SqlCon.Open();
                    SqlCommand cmd = new SqlCommand("sp_RegistroExiste_Producto", SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Pro_Codigo", TxtCodigo.Text);
                    cmd.Parameters.AddWithValue("@Pro_Nombre", TxtNombreProducto.Text);
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
                        SqlCommand cmd2 = new SqlCommand("sp_Insert_Producto", SqlCon);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@Pro_Codigo", TxtCodigo.Text);
                        cmd2.Parameters.AddWithValue("@Pro_Nombre", TxtNombreProducto.Text);
                        cmd2.Parameters.AddWithValue("@Pro_FechaCompra", TxtFechaCompra.Text);
                        cmd2.Parameters.AddWithValue("@Pro_PrecioCompraRD", TxtPrecioCompra.Text);
                        cmd2.Parameters.AddWithValue("@Pro_PrecioCompraUS", TxtPrecioCompraUS.Text);
                        cmd2.Parameters.AddWithValue("@Pro_Bodega", DdlBodega.Text);
                        cmd2.Parameters.AddWithValue("@Pro_Ubicacion", DdlUbicacion.Text);
                        cmd2.Parameters.AddWithValue("@Pro_Status", ChbStatus.Checked);
                        cmd2.Parameters.AddWithValue("@Pro_AplicarItebis", ChbAplicarItebis.Checked);
                        cmd2.Parameters.AddWithValue("@Pro_Fisico", RbtFisico.Checked);
                        cmd2.Parameters.AddWithValue("@Pro_Servicio", RbtServicio.Checked);
                        cmd2.Parameters.AddWithValue("@Pro_Ocasional", RbtOcasional.Checked);
                        cmd2.Parameters.AddWithValue("@Pro_CantidadInicial", TxtCantidadInicial.Text);
                        cmd2.Parameters.AddWithValue("@Pro_CantidadMinima", TxtCantidadMinima.Text);
                        cmd2.Parameters.AddWithValue("@Pro_FechaExpiracion", TxtFechaExpiracion.Text);
                        cmd2.Parameters.AddWithValue("@Pro_Suplidor", DdlSuplidor.Text);
                        cmd2.Parameters.AddWithValue("@Pro_Marca", DdlMarca.Text);
                        cmd2.Parameters.AddWithValue("@Pro_Modelo", DdlModelo.Text);
                        cmd2.Parameters.AddWithValue("@Pro_Serie", TxtSerie.Text);
                        cmd2.Parameters.AddWithValue("@Pro_Color", DdlColor.Text);
                        cmd2.Parameters.AddWithValue("@Pro_Categoria", DdlCategoria.Text);
                        cmd2.Parameters.AddWithValue("@Pro_SubCategoria", DdlSubCategoria.Text);
                        cmd2.Parameters.AddWithValue("@Pro_Referencia", TxtReferencia.Text);
                        cmd2.Parameters.AddWithValue("@Pro_VendePor", DdlSeVende.Text);
                        cmd2.Parameters.AddWithValue("@Pro_ContieneVende", TxtContiene.Text);
                        cmd2.Parameters.AddWithValue("@Pro_CompraPor", DdlSeCompra.Text);
                        cmd2.Parameters.AddWithValue("@Pro_ContieneCompra", TxtContieneCompra.Text);
                        cmd2.Parameters.AddWithValue("@Pro_Nota", TxtNota.Text);
                        cmd2.ExecuteScalar();

                        ImgBarras.ImageUrl = "~/Imagenes/BarraVerde.png";
                        LblMensaje2.Text = "Mensaje.: Registro guardado satisfactoriamente";

                        ImgAceptar.Enabled = false;
                        ImbCancelar.Enabled = false;
                        ImbBuscar.Enabled = false;
                        ImbNuevo.Enabled = true;
                        TxtCodigo.Enabled = false;
                        TxtNombreProducto.Enabled = false;
                        TxtFechaCompra.Enabled = false;
                        TxtPrecioCompra.Enabled = false;
                        TxtPrecioCompraUS.Enabled = false;
                        DdlBodega.Enabled = false;
                        DdlUbicacion.Enabled = false;
                        ChbStatus.Enabled = false;
                        ChbAplicarItebis.Enabled = false;
                        RbtFisico.Enabled = false;
                        RbtServicio.Enabled = false;
                        RbtOcasional.Enabled = false;
                        TxtCantidadInicial.Enabled = false;
                        TxtCantidadMinima.Enabled = false;
                        TxtFechaExpiracion.Enabled = false;
                        DdlSuplidor.Enabled = false;
                        DdlMarca.Enabled = false;
                        DdlModelo.Enabled = false;
                        TxtSerie.Enabled = false;
                        DdlColor.Enabled = false;
                        DdlCategoria.Enabled = false;
                        DdlSubCategoria.Enabled = false;
                        TxtReferencia.Enabled = false;
                        DdlSeVende.Enabled = false;
                        TxtContiene.Enabled = false;
                        DdlSeCompra.Enabled = false;
                        TxtContieneCompra.Enabled = false;
                        TxtNota.Enabled = false;

                        SqlCon.Close();
                    }
                }
            }
            catch
            {
            }
        }

        protected void TxtPrecioCompra_TextChanged(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(TxtPrecioCompra.Text);
            TxtPrecioCompra.Text = dec.ToString("n"); //formato numérico standar
        }

        protected void TxtPrecioCompraUS_TextChanged(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(TxtPrecioCompraUS.Text);
            TxtPrecioCompraUS.Text = dec.ToString("n"); //formato numérico standar
        }

        protected void TxtCantidadInicial_TextChanged(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(TxtCantidadInicial.Text);
            TxtCantidadInicial.Text = dec.ToString("n"); //formato numérico standar
        }

        protected void TxtContiene_TextChanged(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(TxtContiene.Text);
            TxtContiene.Text = dec.ToString("n"); //formato numérico standar
        }

        protected void TxtCantidadMinima_TextChanged(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(TxtCantidadMinima.Text);
            TxtCantidadMinima.Text = dec.ToString("n"); //formato numérico standar
        }

        protected void RbtFisico_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtFisico.Checked == true)
            {
                RbtServicio.Checked = false;
                RbtOcasional.Checked = false;
            }
        }

        protected void RbtServicio_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtServicio.Checked == true)
            {
                RbtFisico.Checked = false;
                RbtOcasional.Checked = false;
            }
        }

        protected void RbtOcasional_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtOcasional.Checked == true)
            {
                RbtServicio.Checked = false;
                RbtFisico.Checked = false;
            }
        }

        protected void TxtContieneCompra_TextChanged(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(TxtContieneCompra.Text);
            TxtContieneCompra.Text = dec.ToString("n"); //formato numérico standar
        }

        protected void ImbNuevo_Click(object sender, ImageClickEventArgs e)
        {
            Reiniciar();
        }

        protected void ImbBuscar_Click(object sender, ImageClickEventArgs e)
        {
            SqlCon = ConexionDB.getInstancia().CrearConexion();
            DataTable dt = new DataTable();
            
            SqlCommand comando = new SqlCommand("sp_Consulta_GridProducto", SqlCon);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(comando);
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SqlCon.Close();

            ImgAceptar.Enabled = false;
        }

        protected void ImbCancelar_Click(object sender, ImageClickEventArgs e)
        {
            Reiniciar();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ImgBarras.ImageUrl = "~/Imagenes/BarraAzul.png";
            LblMensaje2.Text = "Mensajes";
            Timer1.Enabled = false;
        }

        protected void ImbModificar_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtCodigo.Text) || string.IsNullOrWhiteSpace(TxtNombreProducto.Text))
            {
                ImgBarras.ImageUrl = "~/Imagenes/BarraRoja.png";
                LblMensaje2.Text = "Mensaje.:No se puede modificar este registro, debe completar los campos";
                Timer1.Enabled = true;
            }
            else
            {
                //Verificar si existe registro BD
                SqlCon = ConexionDB.getInstancia().CrearConexion();
                SqlCon.Open();

                SqlCommand comando1 = new SqlCommand("sp_Update_Producto", SqlCon);
                comando1.CommandType = CommandType.StoredProcedure;

                comando1.Parameters.AddWithValue("@Pro_Codigo", TxtCodigo.Text);
                comando1.Parameters.AddWithValue("@Pro_Nombre", TxtNombreProducto.Text);
                comando1.Parameters.AddWithValue("@Pro_FechaCompra", TxtFechaCompra.Text);
                comando1.Parameters.AddWithValue("@Pro_PrecioCompraRD", TxtPrecioCompra.Text);
                comando1.Parameters.AddWithValue("@Pro_PrecioCompraUS", TxtPrecioCompraUS.Text);
                comando1.Parameters.AddWithValue("@Pro_Bodega", DdlBodega.Text);
                comando1.Parameters.AddWithValue("@Pro_Ubicacion", DdlUbicacion.Text);
                comando1.Parameters.AddWithValue("@Pro_Status", ChbStatus.Checked);
                comando1.Parameters.AddWithValue("@Pro_AplicarItbis", ChbAplicarItbis.Checked);
                comando1.Parameters.AddWithValue("@Pro_Fisico", RbtFisico.Checked);
                comando1.Parameters.AddWithValue("@Pro_Servicio", RbtServicio.Checked);
                comando1.Parameters.AddWithValue("@Pro_Ocasional", RbtOcasional.Checked);
                comando1.Parameters.AddWithValue("@Pro_CantidadInicial", TxtCantidadInicial.Text);
                comando1.Parameters.AddWithValue("@Pro_CantidadMinima", TxtCantidadMinima.Text);
                comando1.Parameters.AddWithValue("@Pro_FechaExpiracion", TxtFechaExpiracion.Text);
                comando1.Parameters.AddWithValue("@Pro_Suplidor", DdlSuplidor.Text);
                comando1.Parameters.AddWithValue("@Pro_Marca", DdlMarca.Text);
                comando1.Parameters.AddWithValue("@Pro_Modelo", DdlModelo.Text);
                comando1.Parameters.AddWithValue("@Pro_Serie", TxtSerie.Text);
                comando1.Parameters.AddWithValue("@Pro_Color", DdlColor.Text);
                comando1.Parameters.AddWithValue("@Pro_Categoria", DdlCategoria.Text);
                comando1.Parameters.AddWithValue("@Pro_SubCategoria", DdlSubCategoria.Text);
                comando1.Parameters.AddWithValue("@Pro_Referencia", TxtReferencia.Text);
                comando1.Parameters.AddWithValue("@Pro_VendePor", DdlSeVende.Text);
                comando1.Parameters.AddWithValue("@Pro_ContieneVende", TxtContiene.Text);
                comando1.Parameters.AddWithValue("@Pro_CompraPor", DdlSeCompra.Text);
                comando1.Parameters.AddWithValue("@Pro_ContieneCompra", TxtContieneCompra.Text);
                comando1.Parameters.AddWithValue("@Pro_Nota", TxtNota.Text);

                comando1.ExecuteNonQuery();
                SqlCon.Close();

                ImgBarras.ImageUrl = "~/Imagenes/BarraVerde.png";
                LblMensaje2.Text = "Registro modificado exitosamente";
                Timer1.Enabled = true;

                ImbModificar.Enabled = false;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtCodigo.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;
            TxtNombreProducto.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[2].Text;
            TxtFechaCompra.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[3].Text;
            TxtPrecioCompra.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[4].Text;
            TxtPrecioCompraUS.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[5].Text;
            DdlBodega.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[6].Text;
            DdlUbicacion.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[7].Text;

            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCommand comando = new SqlCommand("sp_BuscarRegistro_Status", SqlCon);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Pro_Codigo", TxtCodigo.Text);
            SqlCon.Open();

            SqlDataReader leer = comando.ExecuteReader();
            if (leer.Read() == true)
            {
                try
                {
                    ChbStatus.Checked = Convert.ToBoolean(leer["Pro_Status"]);
                    ChbAplicarItebis.Checked = Convert.ToBoolean(leer["Pro_AplicarItebis"]);

                    RbtFisico.Checked = Convert.ToBoolean(leer["Pro_Fisico"]);
                    RbtServicio.Checked = Convert.ToBoolean(leer["Pro_Servicio"]);
                    RbtOcasional.Checked = Convert.ToBoolean(leer["Pro_Ocasional"]);
                }
                catch
                {
                }
            }
            else
            {
            }

            SqlCon.Close();

            TxtCantidadInicial.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[13].Text;
            TxtCantidadMinima.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[14].Text;
            TxtFechaExpiracion.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[15].Text;
            DdlSuplidor.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[16].Text;
            DdlMarca.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[17].Text;
            DdlModelo.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[18].Text;
            TxtSerie.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[19].Text;
            DdlColor.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[20].Text;
            DdlCategoria.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[21].Text;
            DdlSubCategoria.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[22].Text;
            TxtReferencia.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[23].Text;
            DdlSeVende.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[24].Text;
            TxtContiene.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[25].Text;
            DdlSeCompra.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[26].Text;
            TxtContieneCompra.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[27].Text;
            TxtNota.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[28].Text;

            TxtCodigo.ReadOnly = true;

            ImbModificar.Enabled = true;
        }

        protected void ImbCalendarioCompra_Click(object sender, ImageClickEventArgs e)
        {
            PnlFecheroCompra.Visible = true;
            ImbCalendarioExpiracion.Enabled = false;
        }

        protected void CldCalendarioCompra_SelectionChanged(object sender, EventArgs e)
        {
            if (ImbCalendarioCompra.Enabled == true)
            {
                TxtFechaCompra.Text = CldCalendarioCompra.SelectedDate.ToShortDateString();
            }
            else
            {
                TxtFechaExpiracion.Text = CldCalendarioCompra.SelectedDate.ToShortDateString();
            }

            PnlFecheroCompra.Visible = false;

            ImbCalendarioExpiracion.Enabled = true;
            ImbCalendarioCompra.Enabled = true;
        }

        protected void ImbCalendarioExpiracion_Click(object sender, ImageClickEventArgs e)
        {
            PnlFecheroCompra.Visible = true;
            ImbCalendarioCompra.Enabled = false;
        }
    }
}