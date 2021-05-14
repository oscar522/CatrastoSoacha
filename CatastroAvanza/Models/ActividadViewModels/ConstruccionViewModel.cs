using System.Web;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class ConstruccionViewModel
    {
        public HttpPostedFileBase FotoFachada { get; set; }

        public bool IncorporacioArea { get; set; }

        public string DetalleIncorporacionArea { get; set; }

        public bool Uso { get; set; }

        public bool Destino { get; set; }

        public string ObservacionUsosDestino { get; set; }

        public bool RequiereVisitaConstruccion { get; set; }
    }
}