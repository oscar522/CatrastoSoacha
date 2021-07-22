using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CatastroAvanza.Models.Trabajo
{
    public class CrearTrabajoViewModel
    {

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Nombre es requerido.")]
        public string Nombre { get; set; }
        [DisplayName("Rol")]
        [Required(ErrorMessage = "Rol es requerido.")]
        public string Rol { get; set; }
        [DisplayName("Cantidad")]
        [Required(ErrorMessage = "Cantidad es requerido.")]
        public int Cantidad { get; set; }
        [DisplayName("Puntos de esfuerzo")]
        [Required(ErrorMessage = "Puntos de esfuerzo es requerido.")]
        public int PuntosEsfuerzo { get; set; }

        public SelectList Roles { get; set; }
    }
}