using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Models;
using CatastroAvanza.Models.Archivo;
using System.Threading.Tasks;

namespace CatastroAvanza.Negocio.Contratos
{
    public interface IArchivoLogic
    {
        Task<int> CrearArchivo(CrearArchivoViewModel model, AuditoriaModel auditoriaModel);

        Task<DataTablesResponse> ConsultarArchivos(IDataTablesRequest modelo);
    }
}
