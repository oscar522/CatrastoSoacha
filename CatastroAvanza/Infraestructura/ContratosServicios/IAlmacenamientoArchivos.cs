using System.IO;

namespace CatastroAvanza.Infraestructura.ContratosServicios
{
    public interface IAlmacenamientoArchivos
    {
        CargarArchivoRespuesta GuardarParteArchivoFisico(InformacionParteArchivo archivo);

        void CombinarArchivoCargado(string fileId, string pathAdicional);

        void GuardarArchivoFisico(InformationDocumento archivo);

        FileStream TraerArchivoFisico(string archivo, string pathAdicional);
        
    }
}