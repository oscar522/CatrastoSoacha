using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CatastroAvanza.Models.Archivo
{
    public class CrearArchivoViewModel
    {
        [DisplayName("Nombre archivo")]
        [Required(ErrorMessage = "Nombre archivo es requerido.")]
        public string Nombre { get; set; }

        [DisplayName("Archivo")]
        [Required(ErrorMessage = "Archivo es requerido.")]
        public HttpPostedFileBase Archivo { get; set; }
    }
}