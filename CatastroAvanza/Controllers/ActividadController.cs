using CatastroAvanza.Enumerations;
using CatastroAvanza.Models.ActividadViewModels;
using CatastroAvanza.Negocio.Contratos;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CatastroAvanza.Controllers
{
    public class ActividadController : BaseController
    {
        public ActividadController(ICatalogo catalogos, IActividadLogic actividad)
        {
            _catalogos = catalogos;
            _actividad = actividad;
        }

        private readonly ICatalogo _catalogos;
        private readonly IActividadLogic _actividad;
        // GET: Actividad
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> CrearActividad()
        {
            ActividadGeneralViewModel model = new ActividadGeneralViewModel();

            model.Ejecutores = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.Ejecutor), "Value", "Text", 1);
            model.Coordinadores = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.Coordinador), "Value", "Text", 1);
            model.Terreno.UnidadesArea = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.UnidadArea), "Value", "Text", 1);
            model.Construccion.DetallesIncorporacionArea = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.DetalleIncorporacionArea), "Value", "Text", 1);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CrearActividad(ActividadGeneralViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            else
            {
                await _actividad.CrearActividad(model);
                return RedirectToAction(nameof(Index));
            }
            
        }
    }
}