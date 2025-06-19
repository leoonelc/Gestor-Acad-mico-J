using System;

namespace Gestor_Académico__J.C.Modelos
{
    public class Nota  // <-- Cambiar a public
    {
        public int IdNota { get; set; }
        public int IdEstudiante { get; set; }
        public int IdEvaluacion { get; set; }
        public decimal Calificacion { get; set; }

        // Propiedades adicionales para mostrar nombres en pantalla (opcional)
        public string NombreEstudiante { get; set; }
        public string NombreEvaluacion { get; set; }
    }
}
