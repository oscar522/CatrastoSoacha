using CatastroAvanza.Enumerations;
using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Infraestructura;
using CatastroAvanza.Models.ActividadesDiarias;
using CatastroAvanza.Negocio.Contratos;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CatastroAvanza.Controllers
{
    [Authorize]
    public class ActividadesDiariasController : BaseController
    {
        
        public ActividadesDiariasController(ICatalogo catalogos,ISecurityLogic securityManager, IActividadDiariaLogic actividadDiaria)
        {
            _catalogos = catalogos;
            _securityManager = securityManager;
            _actividadDiaria = actividadDiaria;
        }

        private readonly ICatalogo _catalogos;
        private readonly ISecurityLogic _securityManager;
        private readonly IActividadDiariaLogic _actividadDiaria;

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> CrearActividad()
        {
            return View(new ActividadesDiariasViewModel 
            { 
                NombreUsuario= GetUserName(),                                  
                RolUsuario = GetUserRole() 
            });
        }

        [HttpPost]
        public async Task<ActionResult> CrearActividad(ActividadesDiariasViewModel model)
        {
            if (!ModelState.IsValid)
                return View(nameof(CrearActividad), model);
            else
            {
                model.IdApsNetUser = GetUserName();                
                model.Id = await _actividadDiaria.CrearActividad(model);
                return View(nameof(CrearActividad), new ActividadesDiariasViewModel());
            }            
        }

        [HttpPost]
        public async Task<ActionResult> TipoActividadList(string RolId)
        {                       
            return Json(new SelectList(_catalogos.ObtenerActividadesPorRol(RolId), "Value", "Text", 1));
        }
        [HttpPost]
        public async Task<ActionResult> GetRoles()
        {            
            var roles = _securityManager.GetRoles();
            return Json(new SelectList(roles, "Id", "Name", 1));
        }
        [HttpPost]
        public async Task<ActionResult> GetProcess()
        {
            return Json(new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.Proceso), "Value", "Text", 1));
        }
        [HttpPost]
        public async Task<ActionResult> GetModalidades()
        {
            return Json(new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.Modalidad), "Value", "Text", 1));
        }
        [HttpPost]
        public async Task<ActionResult> GetDepartamentos()
        {            
            return Json(new SelectList(_catalogos.ObtenerDepartamentosPorIdPais(1), "Value", "Text", 1));
        }
        [HttpPost]
        public async Task<ActionResult> GetMunicipios(int IdDepartamento)
        {
            var municipios = new SelectList(_catalogos.ObtenerMunicipiosPorIdDepartamento(IdDepartamento), "Value", "Text", 1);
            return Json(municipios);
        }

        [HttpPost]
        public async Task<ActionResult> ObtenerActividades([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest modelo)
        {

            var tabla = await _actividadDiaria.GetActividadesCreadas(modelo);

            return Json(tabla, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<FileResult> ObtenerExcelActividadesDiarias()
        {
            var actividades = await _actividadDiaria.GetActividadesDiarias();

            GeneracionExcel excel = new GeneracionExcel();

            var excelWorkBook = excel.GenerarArchivoExcelActividadesDiarias(actividades);

            var exportData = new MemoryStream();
            excelWorkBook.Write(exportData);
            exportData.Seek(0, SeekOrigin.Begin);
            return File(exportData, "application/vnd.ms-excel", "actividades.xls");                        
        }
    }
}