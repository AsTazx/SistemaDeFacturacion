using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using Microsoft.Ajax.Utilities;

namespace SistemaDeFacturacionCS
{
    public class ConexionDB
    {
        //Atributos
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;
        private static ConexionDB Con = null;

        //Metodos de conexion
        private ConexionDB()
        {
            this.Base = "Facturacion";

            //------ CASA ------
            this.Servidor = "XESTT";
            this.Usuario = "sa";
            this.Clave = "LOSVILLANOS9z";
            this.Seguridad = false;


            ////----COLE----
            //this.Servidor = "LAB04PC38\\LABO4PC38";
            //this.Usuario = "";
            //this.Clave = "";
            //this.Seguridad = true;

        }

        //Metodo de Conexion efectivo
        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor + ";Database=" + this.Base + ";";
                if (this.Seguridad)
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "Integrated Security=SSPI;";
                }
                else
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "User Id=" + this.Usuario + ";Password=" + this.Clave + ";";
                }
                Cadena.Open();
            }
            catch (Exception ex)
            {
                Cadena = null;

                throw ex;


            }
            return Cadena;
        }

        //Metodo fallo de conexion
        public static ConexionDB getInstancia()
        {
            if (Con == null)
            {
                Con = new ConexionDB();
            }
            return Con;
        }
    }
}