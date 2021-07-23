using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CatastroAvanza.Models.Trabajo
{
    public class ActualizarGestionTrabajoViewModel
    {
        [Required(ErrorMessage = "Id es requerido.")]
        public int Id { get; set; }

        public int IdAsignacion { get; set; }

        [DisplayName("Estado gestion")]
        [Required(ErrorMessage = "Estado gestion es requerido.")]
        public string EstadoGestion { get; set; }

        [DisplayName("Fecha gestion")]
        [Required(ErrorMessage = "Fecha gestion es requerido.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaModificacionGestion { get; set; }
        [DisplayName("Observacion")]
        [Required(ErrorMessage = "Observacion es requerido.")]
        public string Observacion { get; set; }

        public string EstadoRegistro { get; set; }

        public int IdTrabajo { get; set; }
        public string NombreTrabajo { get; set; }
        public SelectList EstadosGestion { get; set; }
    }
}