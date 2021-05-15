using System.Web;

namespace CatastroAvanza.Infraestructura.ContratosServicios
{
    public interface IAlmacenamientoArchivos
    {
        string GuardarArchivoFisico(HttpPostedFileBase archivo);
    }
}