namespace CatastroAvanza.Models.Archivo
{
    public class ArchivoDescargaViewModel
    {
        public ArchivoDescargaViewModel()
        {
            Nombre = string.Empty;
            Archivo = new byte[0];
        }

        public ArchivoDescargaViewModel(string nombre, byte[] archivo)
        {
            Nombre = nombre;
            Archivo = archivo;
        }

        public string Nombre { get; }

        public byte[] Archivo { get; }
    }
}