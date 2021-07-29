using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Models.Archivo;
using CatastroAvanza.Negocio.Contratos;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CatastroAvanza.Controllers
{
    public class ArchivoController : BaseController
    {

        public ArchivoController(IArchivoLogic archivo)
        {
            _archivo = archivo;
        }
       
        private readonly IArchivoLogic _archivo;

        [Authorize]
        public async Task<ActionResult> CrearArchivo()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CrearArchivo(CrearArchivoViewModel model)
        {
            int result =await _archivo.CrearArchivo(model, new Models.AuditoriaModel(GetUserName()));

            if (result != 0)
                return RedirectToAction(nameof(CrearArchivo));

            return View();
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ConsultarArchivos([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest modelo)
        {
            var tabla = await _archivo.ConsultarArchivos(modelo);
            return Json(tabla, JsonRequestBehavior.AllowGet);
        }
    }
}