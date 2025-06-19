using System;

namespace Gestor_Académico__J.C.Modelos
{
    public class Evaluacion  // <-- Cambiado a public
    {
        public int IdEvaluacion { get; set; }
        public string NombreEvaluacion { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; internal set; }
    }
}
