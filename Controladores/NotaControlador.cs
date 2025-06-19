using Gestor_Académico__J.ConexionBD;
using Gestor_Académico__J.C.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Gestor_Académico__J.C.Controladores
{
    internal class NotaControlador
    {
        // Obtener todas las notas con datos relacionados (estudiante y evaluación)
        public List<Nota> ObtenerNotas()
        {
            var lista = new List<Nota>();

            using (var conn = Conexion.ObtenerConexion()) // ✅ Corregido
            {
                conn.Open();
                string query = @"
                    SELECT n.id_nota, n.id_estudiante, n.id_evaluacion, n.calificacion, 
                           e.nombre AS NombreEstudiante, ev.nombre AS NombreEvaluacion
                    FROM Notas n
                    INNER JOIN Estudiantes e ON n.id_estudiante = e.id_estudiante
                    INNER JOIN Evaluaciones ev ON n.id_evaluacion = ev.id_evaluacion";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Nota
                    {
                        IdNota = Convert.ToInt32(reader["id_nota"]),
                        IdEstudiante = Convert.ToInt32(reader["id_estudiante"]),
                        IdEvaluacion = Convert.ToInt32(reader["id_evaluacion"]),
                        Calificacion = Convert.ToDecimal(reader["calificacion"]),
                        NombreEstudiante = reader["NombreEstudiante"].ToString(),
                        NombreEvaluacion = reader["NombreEvaluacion"].ToString()
                    });
                }
            }

            return lista;
        }

        // Agregar nueva nota
        public bool AgregarNota(Nota nota)
        {
            using (var conn = Conexion.ObtenerConexion()) // ✅ Llaves faltaban
            {
                conn.Open();
                string query = "INSERT INTO Notas (id_estudiante, id_evaluacion, calificacion) VALUES (@idEstudiante, @idEvaluacion, @calificacion)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idEstudiante", nota.IdEstudiante);
                cmd.Parameters.AddWithValue("@idEvaluacion", nota.IdEvaluacion);
                cmd.Parameters.AddWithValue("@calificacion", nota.Calificacion);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Actualizar nota
        public bool ActualizarNota(Nota nota)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "UPDATE Notas SET id_estudiante = @idEstudiante, id_evaluacion = @idEvaluacion, calificacion = @calificacion WHERE id_nota = @idNota";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idEstudiante", nota.IdEstudiante);
                cmd.Parameters.AddWithValue("@idEvaluacion", nota.IdEvaluacion);
                cmd.Parameters.AddWithValue("@calificacion", nota.Calificacion);
                cmd.Parameters.AddWithValue("@idNota", nota.IdNota);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Eliminar nota
        public bool EliminarNota(int idNota)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM Notas WHERE id_nota = @idNota";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idNota", idNota);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
