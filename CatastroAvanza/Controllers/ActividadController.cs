using CatastroAvanza.Models.ActividadViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CatastroAvanza.Controllers
{
    public class ActividadController : BaseController
    {
        // GET: Actividad
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CrearActividad()
        {
            ActividadGeneralViewModel model = new ActividadGeneralViewModel();
            model.Ejecutores = new SelectList(new List<SelectListItem> {
                new SelectListItem { Text="Ejecutor 1", Value="1" },
                new SelectListItem { Text="Ejecutor 2", Value="2" },
                new SelectListItem { Text="Ejecutor 3", Value="3" }
            }, "Value", "Text", 1);

            model.Coordinadores = new SelectList(new List<SelectListItem> {
                new SelectListItem { Text="Coordinador 1", Value="1" },
                new SelectListItem { Text="Coordinador 2", Value="2" },
                new SelectListItem { Text="Coordinador 3", Value="3" }
            }, "Value", "Text", 1);
            return View(model);
        }
    }
}