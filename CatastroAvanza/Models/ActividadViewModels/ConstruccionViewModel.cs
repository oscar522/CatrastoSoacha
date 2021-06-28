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

        [DisplayName("Uso")]
        [Required(ErrorMessage = "Uso es requerido.")]
        public string UsoDetalle { get; set; }

        [DisplayName("El destino es correcto?")]
        [Required(ErrorMessage = "El destino es correcto? es requerido.")]
        public bool Destino { get; set; }

        [DisplayName("Destino")]
        [Required(ErrorMessage = "Destino es requerido.")]
        public string DestinoDetalle { get; set; }

        [DisplayName("Observacion")]
        [Required(ErrorMessage = "Observacion del uso del destino es requerido.")]
        public string ObservacionUsosDestino { get; set; }

        [DisplayName("Requiere visita?")]
        [Required(ErrorMessage = "Requiere visita? es requerido.")]
        public bool RequiereVisitaConstruccion { get; set; }

        [DisplayName("Tiene construcciones?")]
        [Required(ErrorMessage = "Tiene construcciones? es requerido.")]
        public bool TieneConstrucciones { get; set; }

        [DisplayName("Requiere rectificar area construida?")]
        [Required(ErrorMessage = "Requiere rectificar area construida? es requerido.")]
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

        [DisplayName("Tiene cubrimiento orto?")]
        [Required(ErrorMessage = "Tiene cubrimiento orto? es requerido.")]
        public bool TieneCubrimientoOrto { get; set; }

        [DisplayName("Tiene cubrimiento visor 360?")]
        [Required(ErrorMessage = "Tiene cubrimiento visor 360? es requerido.")]
        public bool TieneCubrimientoVisor { get; set; }


        public SelectList DetallesIncorporacionArea { get; set; }

        public SelectList Destinos { get; set; }

        public SelectList Usos { get; set; }
    }
}