using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class GeograficaViewModel
    {
        [DisplayName("Omision")]
        [Required(ErrorMessage = "Omision es requerido.")]
        public bool Omision { get; set; }

        [DisplayName("Se encuentra duplicado geograficamente?")]
        [Required(ErrorMessage = "Duplicado geografico es requerido.")]
        public bool DuplicadoGeograficamente { get; set; }

        [DisplayName("Numero de duplicados")]        
        [Required(ErrorMessage = "Numero de duplicados es requerido.")]
        public int NumeroDuplicados { get; set; }

        [DisplayName("Es requerida visita geografica?")]
        [Required(ErrorMessage = "Requiere visita geografica es requerido.")]
        public bool RequiereVisitaGeografica { get; set; }

        [DisplayName("Observacion")]
        [Required(ErrorMessage = "Observacion geografica es requerido.")]
        public string Observacion { get; set; }
    }
}