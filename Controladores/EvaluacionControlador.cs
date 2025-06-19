using Gestor_Académico__J.C.Modelos;
using Gestor_Académico__J.ConexionBD;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Gestor_Académico__J.C.Controladores
{
    public class EvaluacionControlador
    {
        // Agregar evaluación
        public bool Agregar(Evaluacion evaluacion)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "INSERT INTO Evaluaciones (nombre) VALUES (@nombre)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", evaluacion.NombreEvaluacion);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Actualizar evaluación
        public bool Actualizar(Evaluacion evaluacion)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "UPDATE Evaluaciones SET nombre = @nombre WHERE id_evaluacion = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", evaluacion.NombreEvaluacion);
                cmd.Parameters.AddWithValue("@id", evaluacion.IdEvaluacion);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Eliminar evaluación
        public bool Eliminar(int idEvaluacion)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM Evaluaciones WHERE id_evaluacion = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idEvaluacion);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Obtener todas las evaluaciones
        public List<Evaluacion> ObtenerEvaluaciones()
        {
            var lista = new List<Evaluacion>();

            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT id_evaluacion, nombre FROM Evaluaciones";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Evaluacion
                        {
                            IdEvaluacion = reader.GetInt32("id_evaluacion"),
                            NombreEvaluacion = reader.GetString("nombre")
                        });
                    }
                }
            }

            return lista;
        }
    }
}
