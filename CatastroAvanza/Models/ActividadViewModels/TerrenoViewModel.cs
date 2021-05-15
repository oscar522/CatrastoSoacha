using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class TerrenoViewModel
    {
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

        [DisplayName("Escritura del lindero")]
        [Required(ErrorMessage = "Escritura del lindero es requerido.")]
        public string EscrituraLinderos { get; set; }

        [DisplayName("Tiene Area?")]
        [Required(ErrorMessage = "Tiene Area? es requerido.")]
        public bool TieneArea { get; set; }

        [DisplayName("Area del terreno")]
        [Required(ErrorMessage = "Area del terreno es requerido.")]
        public int AreaTerreno { get; set; }

        [DisplayName("Unidad del area")]
        [Required(ErrorMessage = "Unidad del area es requerido.")]
        public int UnidadArea { get; set; }

        [DisplayName("Area del terreno en metros")]
        [Required(ErrorMessage = "Area del terreno en metros es requerido.")]
        public int AreaTerrenoEnMetros { get; set; }

        [DisplayName("Porcentaje del area judicial")]
        [Required(ErrorMessage = "Porcentaje del area judicial es requerido.")]
        public int PorcentajeAreaJudicialAreaCatastral { get; set; }

        [DisplayName("¿El predio esta correctamente identificado?")]
        [Required(ErrorMessage = "¿El predio esta correctamente identificado? es requerido.")]
        public bool IdentificacionPredio { get; set; }

        [DisplayName("Requiere visita")]
        [Required(ErrorMessage = "Requiere visita es requerido.")]
        public string RequiereVisita { get; set; }

        [DisplayName("Observacion de la visita")]
        [Required(ErrorMessage = "Observacion de la visita es requerido.")]
        public string ObservacionVisita { get; set; }

        public SelectList UnidadesArea { get; set; }
    }
}