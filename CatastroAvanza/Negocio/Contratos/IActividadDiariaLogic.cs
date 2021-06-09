using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Models.ActividadesDiarias;
using System.Threading.Tasks;

namespace CatastroAvanza.Negocio.Contratos
{
    public interface IActividadDiariaLogic
    {
        Task<int> CrearActividad(ActividadesDiariasViewModel modelo);

        Task<DataTablesResponse> GetActividadesCreadas(IDataTablesRequest modelo);
    }
}
