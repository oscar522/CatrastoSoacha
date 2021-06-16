using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Models.ActividadViewModels;
using System.Threading.Tasks;

namespace CatastroAvanza.Negocio.Contratos
{
    public interface IActividadLogic
    {
        Task<int> CrearActividad(ActividadPredioViewModel model);

        Task<int> ActualizarActividad(ActividadPredioViewModel model);

        Task<DataTablesResponse> ConsultarActividades(IDataTablesRequest modelo);

        Task<ActividadPredioViewModel> ConsultarActividadPorId(int Id);
    }
}