using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class TerrenoViewModel
    {

        [DisplayName("Tiene Area juridica?")]
        [Required(ErrorMessage = "Tiene Area juridica? es requerido.")]
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
        public bool RequiereVisita { get; set; }

        [DisplayName("Observacion de la visita")]
        [Required(ErrorMessage = "Observacion de la visita es requerido.")]
        public string ObservacionVisita { get; set; }

        public SelectList UnidadesArea { get; set; }
    }
}