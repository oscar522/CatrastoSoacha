namespace CatastroAvanza.Models.Security
{
    public class UserViewModel
    {

        public string UserID { get; set; }
        public string Email { get; set; }

        public string Estado { get; set; }        

        public string Documento { get; set; }

        public int TipoDocumento { get; set; }

        public string TipoDocumentoNombre { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Telefono { get; set; }

        public string rol { get; set; }
    }
}