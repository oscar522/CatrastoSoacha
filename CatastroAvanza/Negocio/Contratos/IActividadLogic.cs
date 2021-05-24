using CatastroAvanza.Models.ActividadViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatastroAvanza.Negocio.Contratos
{
    public interface IActividadLogic
    {
        Task<int> CrearActividad(ActividadPredioViewModel model);

        Task<List<ActividadConsultaViewModel>> ConsultarActividades();


    }
}