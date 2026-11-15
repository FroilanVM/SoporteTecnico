using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SoporteTecnico
{
    public class ConexionBasedeDatos
    {
        // Metodo para obtener la conexion a la base de datos
        public SqlConnection ObtenerConexion()
        {
            string cadena = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            SqlConnection conexion = new SqlConnection(cadena);

            return conexion;
        }
    }
}