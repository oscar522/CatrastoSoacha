using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Models.ActividadViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatastroAvanza.Negocio.Contratos
{
    public interface IActividadLogic
    {
        Task<int> CrearActividad(ActividadPredioViewModel model);

        Task<int> ActualizarActividad(ActividadPredioViewModel model, string Umodificacion);

        Task<DataTablesResponse> ConsultarActividades(IDataTablesRequest modelo);

        Task<ActividadPredioViewModel> ConsultarActividadPorId(int Id);

        Task<List<ActividadExcelModel>> ConsultarActividadExcel();
    }
}