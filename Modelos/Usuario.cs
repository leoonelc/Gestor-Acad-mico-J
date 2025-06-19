namespace Gestor_Académico__J.C.Modelos
{
    public class Usuario  // <-- cambiar a public
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string UsuarioLogin { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; } // admin, profesor
    }
}
