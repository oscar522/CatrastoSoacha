using CatastroAvanza.Infraestructura.ContratosServicios;
using System.Web;

namespace CatastroAvanza.Infraestructura.ImplementacionesServicios
{
    public class AlmacenamientoArchivos : IAlmacenamientoArchivos
    {
        public string GuardarArchivoFisico(HttpPostedFileBase archivo)
        {
            return string.Empty;
            //throw new NotImplementedException();
        }
    }
}