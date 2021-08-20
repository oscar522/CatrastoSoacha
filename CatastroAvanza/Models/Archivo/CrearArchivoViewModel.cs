using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CatastroAvanza.Models.Archivo
{
    public class CrearArchivoViewModel
    {
        [DisplayName("Nombre archivo")]
        [Required(ErrorMessage = "Nombre archivo es requerido.")]
        public string fileRelativePath { get; set; }

        [DisplayName("Archivo")]
        [Required(ErrorMessage = "Archivo es requerido.")]
        public HttpPostedFileBase Archivo { get; set; }

        public string fileId { get; set; }

        public HttpPostedFileBase fileBlob { get; set; }
        public string fileName { get; set; }
        public double fileSize { get; set; }
        public int chunkIndex { get; set; }
        public double chunkSize { get; set; }
        public double chunkSizeStart { get; set; }
        public int chunkCount { get; set; }
        public int retryCount { get; set; }

    }
}