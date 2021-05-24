using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class ConstruccionViewModel
    {

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

        [DisplayName("Tiene construcciones?")]
        [Required(ErrorMessage = "Tiene construcciones? es requerido.")]
        public bool TieneConstrucciones { get; set; }

        [DisplayName("La construccion esta correctamente determinada?")]
        [Required(ErrorMessage = "La construccion esta correctamente determinada? es requerido.")]
        public bool ConstruccionEsCorrecta { get; set; }

        [DisplayName("Se debe adicionar o cancelar unidades?")]
        [Required(ErrorMessage = "Se debe adicionar o cancelar unidades? es requerido.")]
        public bool AdicionaCancelaUnidades { get; set; }

        [DisplayName("Adicionar construcciones")]
        [Required(ErrorMessage = "Adicionar construcciones es requerido.")]
        public bool AdicionarConstrucciones { get; set; }
        [DisplayName("Eliminar construcciones")]
        [Required(ErrorMessage = "Eliminar construcciones es requerido.")]
        public bool ElminarConstrucciones { get; set; }

        [DisplayName("Adicionar anexos")]
        [Required(ErrorMessage = "Adicionar anexos es requerido.")]
        public bool AdicionarAnexos { get; set; }

        [DisplayName("Elminar anexos")]
        [Required(ErrorMessage = "Elminar anexos es requerido.")]
        public bool ElminarAnexos { get; set; }

        public SelectList DetallesIncorporacionArea { get; set; }
    }
}