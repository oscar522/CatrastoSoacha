using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class ConstruccionViewModel
    {
        [DisplayName("Foto de la fachada")]
        [Required(ErrorMessage = "Foto de la fachada es requerido.")]
        public HttpPostedFileBase FotoFachada { get; set; }

        [DisplayName("Area Incorporada?")]
        [Required(ErrorMessage = "Area Incorporada? es requerido.")]
        public bool IncorporacioArea { get; set; }

        [DisplayName("Detalle de la incorporacion")]
        [Required(ErrorMessage = "Detalle de la incorporacion es requerido.")]
        public string DetalleIncorporacionArea { get; set; }

        [DisplayName("El uso es correcto?")]
        [Required(ErrorMessage = "El uso es correcto? es requerido.")]
        public bool Uso { get; set; }

        [DisplayName("El destino es correcto?")]
        [Required(ErrorMessage = "El destino es correcto? es requerido.")]
        public bool Destino { get; set; }

        [DisplayName("Observacion")]
        [Required(ErrorMessage = "Observacion del uso del destino es requerido.")]
        public string ObservacionUsosDestino { get; set; }

        [DisplayName("Requiere visita?")]
        [Required(ErrorMessage = "Requiere visita? es requerido.")]
        public bool RequiereVisitaConstruccion { get; set; }

        public SelectList DetallesIncorporacionArea { get; set; }
    }
}