using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class TramiteViewModel
    {
        [DisplayName("¿Existe englobe?")]
        [Required(ErrorMessage = "¿Existe englobe? es requerido.")]
        public bool Englobe { get; set; }

        [DisplayName("¿Existe desenglobe?")]
        [Required(ErrorMessage = "¿Existe desenglobe? es requerido.")]
        public bool Desenglobe { get; set; }

        [DisplayName("Unidad de tramite")]
        [Required(ErrorMessage = "Unidad de tramite es requerido.")]
        public int Unidadestramite { get; set; }

        [DisplayName("¿Existe reglamento de PH?")]
        [Required(ErrorMessage = "¿Existe reglamento de PH? es requerido.")]
        public bool ReglamentoPH { get; set; }

        [DisplayName("Unidades reglamento")]
        [Required(ErrorMessage = "Unidades reglamento es requerido.")]
        public int UnidadesReglamento { get; set; }

        
    }
}