using System.Collections.Generic;

namespace CatastroAvanza.Models.Trabajo
{
    public class GraficaTrabajoViewModel
    {
        public GraficaTrabajoViewModel()
        {
            data = new List<GraficaTrabajoDataViewModel>();
        }
        public string name { get; set; }

        public ICollection<GraficaTrabajoDataViewModel> data { get; set; }
    }
}