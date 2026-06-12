using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoSena.Datos
{
    public class ConexionDB
    {
        private static readonly string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;

        public static SqlConnection MtAbrirConexion()
       {
            if (string.IsNullOrWhiteSpace(cadenaConexion))
            {
                throw new Exception("La cadena de conexion no se a configurado correctamente ");


            }

            return new SqlConnection(cadenaConexion);
        
        }
    }
}