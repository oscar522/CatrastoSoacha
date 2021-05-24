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

        [DisplayName("¿El FMI esta asigando correctamente al predio?")]
        [Required(ErrorMessage = "¿El FMI esta asigando correctamente al predio? es requerido.")]
        public bool VerificacionFmi { get; set; }

        [DisplayName("Duplicados de FMI")]
        [Required(ErrorMessage = "Duplicados de FMI es requerido.")]
        public bool FmiDuplicados { get; set; }

        [DisplayName("Numero de Duplicados del FMI")]
        [Required(ErrorMessage = "Numero de Duplicados del FMI es requerido.")]
        public int NumeroFmiDuplicados { get; set; }


        [DisplayName("FMI correcto")]
        [Required(ErrorMessage = "FMI correcto es requerido.")]
        public string FmiCorrecto { get; set; }

    }
}