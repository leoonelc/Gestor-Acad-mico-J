using System;

namespace Gestor_Académico__J.C.Modelos
{
    public class Estudiante  // <-- cambiar a public
    {
        public int IdEstudiante { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
