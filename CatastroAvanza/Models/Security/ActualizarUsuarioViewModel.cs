using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CatastroAvanza.Models.Security
{
    public class ActualizarUsuarioViewModel
    {
        [Required(ErrorMessage = "El id de usuario es requerido.")]
        public string UserId { get; set; }

        [EmailAddress(ErrorMessage = "El email es invalido.")]
        [Required(ErrorMessage = "Email es requerido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Documento es requerido.")]
        [Display(Name = "Documento")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Tipo Documento es requerido.")]
        [Display(Name = "Tipo Documento")]
        public int TipoDocumento { get; set; }

        [Required(ErrorMessage = "Nombres es requerido.")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Apellidos es requerido.")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Rol es requerido.")]
        [Display(Name = "Rol")]
        public string Rol { get; set; }

        [Required(ErrorMessage = "Telefono es requerido.")]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        public SelectList Roles { get; set; }

        public SelectList TiposDocumento { get; set; }

        public string Estado { get; set; }
    }
}