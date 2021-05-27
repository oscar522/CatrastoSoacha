namespace CatastroAvanza.Infraestructura.ContratosServicios
{
    public interface IAlmacenamientoArchivos
    {
        void GuardarArchivoFisico(InformationDocumento archivo);

        byte[] TraerArchivoFisico(InformationDocumento archivo);
    }
}