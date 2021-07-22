using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatastroAvanza.Models.Trabajo
{
    public class CreaAsignacionTrabajoViewModel
    {
        [DisplayName("Usuario asignado")]
        [Required(ErrorMessage = "Usuario asignado es requerido.")]
        public string UserAsignado { get; set; }

        [DisplayName("Actividad")]
        [Required(ErrorMessage = "Actividad es requerido.")]
        public int IdActividad { get; set; }

        public string NombreActividad { get; set; }
        [DisplayName("Fecha asignacion")]
        public DateTime FechaAsignacion { get; set; }

        [DisplayName("Usuario que realiza la asignacion")]        
        public string UsuarioQueAsigno { get; set; }
    }
}