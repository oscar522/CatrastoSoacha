using System.IO;

namespace CatastroAvanza.Models.Archivo
{
    public class ArchivoDescargaViewModel
    {
        public ArchivoDescargaViewModel()
        {
            Nombre = string.Empty;
            Archivo = null;
        }

        public ArchivoDescargaViewModel(string nombre, FileStream archivo)
        {
            Nombre = nombre;
            Archivo = archivo;
        }

        public string Nombre { get; }

        public FileStream Archivo { get; }
    }
}