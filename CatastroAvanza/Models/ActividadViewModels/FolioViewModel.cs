using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class FolioViewModel
    {
        [DisplayName("FMI")]
        [Required(ErrorMessage = "FMI es requerido.")]
        public HttpPostedFileBase Fmi { get; set; }

        [DisplayName("Duplicados de FMI")]
        [Required(ErrorMessage = "Duplicados de FMI es requerido.")]
        public bool FmiDuplicados { get; set; }

        [DisplayName("Numero de Duplicados del FMI")]
        [Required(ErrorMessage = "Numero de Duplicados del FMI es requerido.")]
        public int NumeroFmiDuplicados { get; set; }

        [DisplayName("¿El FMI esta asigando correctamente al predio?")]
        [Required(ErrorMessage = "¿El FMI esta asigando correctamente al predio? es requerido.")]
        public bool VerificacionFmi { get; set; }

        [DisplayName("FMI correcto")]
        [Required(ErrorMessage = "FMI correcto es requerido.")]
        public string FmiCorrecto { get; set; }
    }
}