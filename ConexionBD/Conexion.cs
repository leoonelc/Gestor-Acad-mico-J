using System;
using MySql.Data.MySqlClient;

namespace Gestor_Académico__J.ConexionBD
{
    public class Conexion
    {
        private MySqlConnection conexion;

        public static string ObtenerCadenaConexion()
        {
            // Para entorno local sin contraseña
            return "server=localhost;database=gestor_academico;uid=root;pwd=;";
        }

        public static MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(ObtenerCadenaConexion());
        }

        public MySqlConnection AbrirConexion()
        {
            conexion = new MySqlConnection(ObtenerCadenaConexion());
            conexion.Open();
            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
