using System.Web;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class FolioViewModel
    {
        public string Fmi { get; set; }

        public bool FmiDuplicados { get; set; }

        public int NumeroFmiDuplicados { get; set; }

        public bool VerificacionFmi { get; set; }

        public HttpPostedFileBase FmiCorrecto { get; set; }
    }
}