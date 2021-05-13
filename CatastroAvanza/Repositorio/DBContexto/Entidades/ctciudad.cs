namespace CatastroAvanza.Repositorio.DBContexto.Entidades
{
    public class ctciudad
    {
        public int id { get; set; }

        public int idctpais { get; set; }

        public int idctdepto { get; set; }

        public int idctmuncipio { get; set; }

        public string nombre { get; set; }

        public int estado { get; set; }

        public bool zonafocalizada { get; set; }

        public bool flagfocalizado { get; set; }
    }
}