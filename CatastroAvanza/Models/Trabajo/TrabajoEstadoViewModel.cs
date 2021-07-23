using System.Collections.Generic;

namespace CatastroAvanza.Models.Trabajo
{
    public class TrabajoEstadoViewModel
    {
        public TrabajoEstadoViewModel()
        {
            EstadoGestion = new List<TrabajoEstadoValueViewModel>();
        }

        public ICollection<TrabajoEstadoValueViewModel> EstadoGestion { get; private set; }

        public int TotalGestiones { get; private set; }


        public void AddEstado(string nombre,int cuenta)
        {
            EstadoGestion.Add(new TrabajoEstadoValueViewModel { Key= nombre, Value= cuenta } );
        }

        public void SetTotal()
        { 
            foreach(var estado in EstadoGestion)
            {
                TotalGestiones =+ estado.Value;
            }
            
        }
    }
}