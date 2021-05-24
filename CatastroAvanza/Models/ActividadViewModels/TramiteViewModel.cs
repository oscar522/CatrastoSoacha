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

        [DisplayName("¿Requiere actualizacion de propietarios?")]
        [Required(ErrorMessage = "Indicar si los propietarios son correctos requerido.")]
        public bool PropietariosCorrectos { get; set; }

        [DisplayName("Tiene linderos?")]
        [Required(ErrorMessage = "Tiene linderos? es requerido.")]
        public bool Linderos { get; set; }

        [DisplayName("FMI del lindero")]
        [Required(ErrorMessage = "FMI del lindero es requerido.")]
        public string LinderosFmi { get; set; }

        [DisplayName("Tiene linderos arcifinios?")]
        [Required(ErrorMessage = "Tiene linderos arcifinios? es requerido.")]
        public bool LinderosArcifinios { get; set; }

        [DisplayName("Los linderos son verificables?")]
        [Required(ErrorMessage = "Los linderos son verificables? es requerido.")]
        public bool LinderosVerificablesTerreno { get; set; }

        [DisplayName("Linderos en escritura?")]
        [Required(ErrorMessage = "Linderos en escritura? es requerido.")]
        public bool LinderosEnEscritura { get; set; }

        [DisplayName("Numero de escritura")]
        [Required(ErrorMessage = "Numero de escritura es requerido.")]
        public string NumeroEscritura { get; set; }
    }
}