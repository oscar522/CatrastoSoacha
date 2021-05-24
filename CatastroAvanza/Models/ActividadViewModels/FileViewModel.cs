using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class FileViewModel
    {
        [DisplayName("FMI")]
        //[Required(ErrorMessage = "FMI es requerido.")]
        public HttpPostedFileBase Fmi { get; set; }

        [DisplayName("Foto de la fachada")]
        //[Required(ErrorMessage = "Foto de la fachada es requerido.")]
        public HttpPostedFileBase FotoFachada { get; set; }

        [DisplayName("Certificado de la Nomenclatura")]
        //[Required(ErrorMessage = "Certificado de la Nomenclatura es requerido.")]
        public HttpPostedFileBase CertificadoNomenclatura { get; set; }

        [DisplayName("Ficha predial")]
        //[Required(ErrorMessage = "Ficha predial es requerido.")]
        public HttpPostedFileBase FichaPredial { get; set; }

        [DisplayName("Plano")]
        //[Required(ErrorMessage = "Plano es requerido.")]
        public HttpPostedFileBase Plano { get; set; }

        [DisplayName("Escrituras")]
        //[Required(ErrorMessage = "Escrituras es requerido.")]
        public HttpPostedFileBase Escrituras { get; set; }

        [DisplayName("Croquis")]
        //[Required(ErrorMessage = "Croquis es requerido.")]
        public HttpPostedFileBase Croquis { get; set; }
    }
}