using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Infraestructura;
using CatastroAvanza.Models;
using CatastroAvanza.Models.Archivo;
using System.Threading.Tasks;

namespace CatastroAvanza.Negocio.Contratos
{
    public interface IArchivoLogic
    {
        Task<CargarArchivoRespuesta> CrearParteArchivo(CrearArchivoViewModel model);

        Task<int> CompletarCreacionArchivo(string fileId);

        Task<int> CrearArchivo(CrearArchivoViewModel model, AuditoriaModel auditoriaModel);

        Task<DataTablesResponse> ConsultarArchivos(IDataTablesRequest modelo);

        Task<ArchivoDescargaViewModel> DescargarArchivo(int ArchivoId);
    }
}
