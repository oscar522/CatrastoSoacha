namespace CatastroAvanza.Repositorio.DBContexto.Entidades
{
    public class TipoActividad
    {
        public int Id { get; set; }

        public string Actividad { get; set; }

        public bool Estado { get; set; }

        public string IdRol { get; set; }
    }
}