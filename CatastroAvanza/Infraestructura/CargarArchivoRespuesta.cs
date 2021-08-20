using System.Collections.Generic;

namespace CatastroAvanza.Infraestructura
{
    public class CargarArchivoRespuesta
    {
        public CargarArchivoRespuesta()
        {
            Errors = new List<string>();
            initialPreviewConfig = new InitialPreviewConfig();
        }

        public int chunkIndex { get; set; }

        public string DirectoryName { get; set; }

        public ICollection<string> Errors { get; set; }

        public InitialPreviewConfig initialPreviewConfig { get; set; }

    }
}