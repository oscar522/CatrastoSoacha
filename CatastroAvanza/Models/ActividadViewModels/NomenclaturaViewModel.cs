using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class NomenclaturaViewModel
    {

        [DisplayName("¿Requiere actualizacion de nomenclatura?")]
        [Required(ErrorMessage = "¿Requiere actualizacion de nomenclatura? es requerido.")]
        public bool NomenclaturaPredio { get; set; }

        [DisplayName("Nomenclatura a actualizar")]
        [Required(ErrorMessage = "Nomenclatura a actualizar es requerido.")]
        public string NomenclaturaAActualizar { get; set; }
    }
}