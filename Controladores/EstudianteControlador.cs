using Gestor_Académico__J.C.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Gestor_Académico__J.C.Controladores
{
    internal class EstudianteControlador
    {
        // Listar todos los estudiantes
        public List<Estudiante> ObtenerEstudiantes()
        {
            List<Estudiante> lista = new List<Estudiante>();

            using (var conn = ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM Estudiantes";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Estudiante
                    {
                        IdEstudiante = Convert.ToInt32(reader["id_estudiante"]),
                        Cedula = reader["cedula"].ToString(),
                        Nombre = reader["nombre"].ToString(),
                        Correo = reader["correo"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(reader["fecha_nacimiento"])
                    });
                }
            }

            return lista;
        }
        // Actualizar estudiante existente
        public bool ActualizarEstudiante(Estudiante est)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                string query = "UPDATE Estudiantes SET cedula = @cedula, nombre = @nombre, correo = @correo, fecha_nacimiento = @fecha WHERE id_estudiante = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cedula", est.Cedula);
                cmd.Parameters.AddWithValue("@nombre", est.Nombre);
                cmd.Parameters.AddWithValue("@correo", est.Correo);
                cmd.Parameters.AddWithValue("@fecha", est.FechaNacimiento);
                cmd.Parameters.AddWithValue("@id", est.IdEstudiante);  // Asegúrate que la clase Estudiante tenga la propiedad IdEstudiante

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Actualizar estudiante existente
        public bool ActAgregarEstudiante (Estudiante est)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                string query = "UPDATE Estudiantes SET cedula = @cedula, nombre = @nombre, correo = @correo, fecha_nacimiento = @fecha WHERE id_estudiante = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cedula", est.Cedula);
                cmd.Parameters.AddWithValue("@nombre", est.Nombre);
                cmd.Parameters.AddWithValue("@correo", est.Correo);
                cmd.Parameters.AddWithValue("@fecha", est.FechaNacimiento);
                cmd.Parameters.AddWithValue("@id", est.IdEstudiante);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Eliminar estudiante
        public bool EliminarEstudiante(int idEstudiante)
        {
            try
            {
                using (var conexion = ObtenerConexion())
                {
                    conexion.Open();
                    string query = "DELETE FROM Estudiantes WHERE id_estudiante = @idEstudiante";
                    using (var comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@idEstudiante", idEstudiante);
                        return comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar estudiante: {ex.Message}");
                return false;
            }
        }

        // Método para obtener la conexión
        private MySqlConnection ObtenerConexion()
        {
            // Cambia estos datos según tu servidor MySQL, base de datos, usuario y contraseña
            string connectionString = "server=localhost;database=gestor_academico;uid=root;pwd=;";
            return new MySqlConnection(connectionString);
        }

    }
}
