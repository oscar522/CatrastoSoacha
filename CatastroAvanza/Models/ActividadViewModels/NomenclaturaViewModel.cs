using System.Web;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class NomenclaturaViewModel
    {
        public HttpPostedFileBase CertificadoNomenclatura { get; set; }

        public bool NomenclaturaPredio { get; set; }

        public string NomenclaturaAActualizar { get; set; }
    }
}