using System.IO;

namespace CatastroAvanza.Infraestructura.ContratosServicios
{
    public interface IAlmacenamientoArchivos
    {
        void GuardarArchivoFisico(InformationDocumento archivo);

        FileStream TraerArchivoFisico(string archivo, string pathAdicional);
    }
}