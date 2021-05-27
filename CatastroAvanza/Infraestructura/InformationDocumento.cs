using System.IO;
using System.Web;

namespace CatastroAvanza.Infraestructura
{
    public class InformationDocumento
    {
        public InformationDocumento(HttpPostedFileBase archivoWeb, string pathAdicional)
        {
            if (archivoWeb != null)
            {
                NombreArchivo = archivoWeb.FileName;
                Formato = Path.GetExtension(archivoWeb.FileName);
                PathAdicional = pathAdicional;

                MemoryStream target = new MemoryStream();
                archivoWeb.InputStream.CopyTo(target);
                DocumentoBinario = target.ToArray();
            }
        }

        public byte[] DocumentoBinario { get; private set; }

        public string NombreArchivo { get; private set; }

        public string Formato { get; private set; }

        public string PathAdicional { get; private set; }

        public bool ValidarSiUnDocumentoPuedeSerCreado()
        {
            if (string.IsNullOrEmpty(NombreArchivo))
                return false;

            if (string.IsNullOrEmpty(Formato))
                return false;

            if (!string.IsNullOrEmpty(NombreArchivo) && !string.IsNullOrEmpty(Formato) && File.Exists(PathAdicional))
                return false;

            if (DocumentoBinario == null)
                return false;

            return true;
        }

        public bool ValidarElDocumentoPuedeSerBuscado()
        {
            if (string.IsNullOrEmpty(NombreArchivo))
                return false;


            if (!File.Exists(PathAdicional))
                return false;

            return true;
        }

        
    }
}