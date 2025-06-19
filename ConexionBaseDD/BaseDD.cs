using System;
using MySql.Data.MySqlClient;

namespace Gestor_Académico__J.C.BaseDD

{
    class BaseDD
    {
        //sqlconnecction    Sirve para abrir o cerar la conexion a la base de datos
        private readonly string cadenaConexion =
            "server=localhost;database=gestor_academico;uid=root;pwd=;";
        private MySqlConnection conexion;

        public MySqlConnection AbrirConexion()
        {
            conexion = new MySqlConnection(cadenaConexion);
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
